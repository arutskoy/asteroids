using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Transform))]
public sealed class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private int _initialCount;

    private Transform _transform;

    private Queue<Bullet> _bullets;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _bullets = new Queue<Bullet>(_initialCount);

        foreach (var _ in Enumerable.Range(1, _initialCount))
        {
            CreateBullet();
        }
    }

    public Bullet Get()
    {
        if (_bullets.Count == 0)
        {
            CreateBullet();
        }

        var bullet = _bullets.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    private void CreateBullet()
    {
        var bulletGameObject = Instantiate(_bulletPrefab.gameObject, _transform);
        bulletGameObject.SetActive(false);
        var bullet = bulletGameObject.GetComponent<Bullet>();

        bullet.Released += () => { _bullets.Enqueue(bullet); };

        _bullets.Enqueue(bullet);
    }
}