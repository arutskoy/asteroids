using System;

public sealed class Gun : IWeapon
{
    public int Ammo { get; }

    public Gun()
    {
        Ammo = int.MaxValue;
    }

    public void Fire()
    {
        Fired?.Invoke();
    }

    public event Action Fired;
}