using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Spaceship))]
public sealed class SpaceshipEventsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullets;

    private Spaceship _spaceship;

    private Rigidbody2D _rigidbody;

    private Transform _transform;

    private BulletLauncher _bulletLauncher;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spaceship = GetComponent<Spaceship>();
        _bulletLauncher = _bullets.GetComponent<BulletLauncher>();

        _spaceship.Accelerated += OnAccelerated;
        _spaceship.Rotated += OnRotated;
        _spaceship.Gun.Fired += OnGunFired;
    }

    private void OnDisable()
    {
        _spaceship.Accelerated -= OnAccelerated;
        _spaceship.Rotated -= OnRotated;
        _spaceship.Gun.Fired -= OnGunFired;
    }

    private void OnGunFired()
    {
        _bulletLauncher.Launch(_transform.position, _transform.rotation);
    }

    private void OnRotated(Rotation rotation, float rotationSpeed)
    {
        var factor = rotation == Rotation.CW ? -1 : 1;
        _rigidbody.AddTorque(factor * rotationSpeed);
    }

    private void OnAccelerated(float acceleration)
    {
        _rigidbody.AddForce(_transform.up * acceleration);
    }

    
}