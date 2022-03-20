using System;

public interface IWeapon
{
    int Ammo { get; } 
    
    void Fire();

    event Action Fired;
}