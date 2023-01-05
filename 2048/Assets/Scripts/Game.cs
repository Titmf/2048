using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CubeMerger _cubeMerger;
    [SerializeField] private Transform _catapultLocation;
    [SerializeField] private Fabric _fabric;
    [SerializeField] private UIHandle _uiHandle;
    [SerializeField] private Catapult _catapult;
    
    private void OnEnable()
    {
        _uiHandle.MouseDown += _catapult.LoadInto;
        _uiHandle.MouseUp += _catapult.ThrowProjectile;
    }
    private void OnDisable()
    {
        _uiHandle.MouseDown -= _catapult.LoadInto;
        _uiHandle.MouseUp -= _catapult.ThrowProjectile;
    }

    public Cube SpawnCube()
    {
        var cube = _fabric.CreateCubeWithRandomNumber(_catapultLocation.position);
        cube.CollisionWithSameCube += OnCollisionWith;
        
        return cube;
    }
    
    private void OnCollisionWith(Cube cube1, Cube cube2)
    {
        _cubeMerger.Merge(cube1, cube2);
    }
}