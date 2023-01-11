using UnityEngine;

public class Catapult: MonoBehaviour
{
    [SerializeField] private float _cubeKickForce = 10f;
    [SerializeField] private Game _game;
    [SerializeField] private Transform _catapultLocation;

    private Cube _loadedProjectile;

    public void LoadInto()
    {
        _loadedProjectile = _game.SpawnCube();
    }
    public void ThrowProjectile()
    {
        _loadedProjectile.Kick(Vector3.forward * _cubeKickForce);
        _loadedProjectile = null;
    }
    public void ProjectileFollowing()
    {
        if (_loadedProjectile != null)
        {
            _loadedProjectile.transform.position = _catapultLocation.position;   
        }
    }
}