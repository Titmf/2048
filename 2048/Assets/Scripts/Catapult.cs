using UnityEngine;

public class Catapult: MonoBehaviour
{
    [SerializeField] private float _cubeKickForce = 10f;

    private Cube _loadedProjectile;

    public void Attach(Cube cube)
    {
        _loadedProjectile = cube;
    }
    public void ThrowProjectile()
    {
        _loadedProjectile.Kick(Vector3.forward * _cubeKickForce);
    }
    public void ProjectileFollowing(Vector3 position)
    {
        _loadedProjectile.transform.position = position;
    }
}