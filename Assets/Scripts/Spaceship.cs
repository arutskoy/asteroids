using System;
using UnityEngine;

public sealed class Spaceship : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _acceleration;

    public Spaceship()
    {
        Gun = new Gun();
    }

    public void Accelerate()
    {
        Accelerated?.Invoke(_acceleration);
    }

    public void RotateRight()
    {
        Rotated?.Invoke(Rotation.CW, _rotationSpeed);
    }

    public void RotateLeft()
    {
        Rotated?.Invoke(Rotation.CCW, _rotationSpeed);
    }

    public IWeapon Gun { get; }

    public event Action<Rotation, float> Rotated;

    public event Action<float> Accelerated;
}