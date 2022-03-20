using UnityEngine;


[RequireComponent(typeof(BulletPool))]
public sealed class BulletLauncher : MonoBehaviour
{
    private BulletPool _pool;

    private void Awake()
    {
        _pool = GetComponent<BulletPool>();
    }

    public void Launch(Vector2 position, Quaternion rotation)
    {
        var bullet = _pool.Get();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.Launch();
    }
}