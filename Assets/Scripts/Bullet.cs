using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    [SerializeField] private float _lifetimeMs;

    private DateTime _alive;

    private Rigidbody2D _rigidbody;

    public void Launch()
    {
        _alive = DateTime.UtcNow;
        _rigidbody.AddForce(transform.up * _speed);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((DateTime.UtcNow - _alive).TotalMilliseconds >= _lifetimeMs) Release();
    }

    private void OnCollisionEnter2D()
    {
        Release();
    }

    private void Release()
    {
        gameObject.SetActive(false);
        Released?.Invoke();
    }

    public event Action Released;
}