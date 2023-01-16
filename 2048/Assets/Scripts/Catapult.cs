using UnityEngine;

public class Catapult: MonoBehaviour
{
    [SerializeField] private float _cubeKickForce = 10f;
    [SerializeField] private Game _game;

    private Cube _loadedProjectile;

    private Vector3 _offsetDelta;

    public void LoadInto()
    {
        _loadedProjectile = _game.SpawnCube();
    }
    public void ThrowProjectile()
    {
        _loadedProjectile.Kick(Vector3.forward * _cubeKickForce);
    }
    public void ProjectileFollowing(Vector2 deltaValue)
    {
        _offsetDelta = new Vector3(deltaValue.x, 0, 0);
        _loadedProjectile.transform.position += _offsetDelta;
    }
}