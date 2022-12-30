using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CubeMerger _cubeMerger;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Fabric _fabric;
    [SerializeField] private UIHandle _uiHandle;
    [SerializeField] private float _cubeKickForce = 10f;

    private Cube _tackedCube;
    
    private void OnEnable()
    {
        _uiHandle.MouseDown += OnMouseDown;
        _uiHandle.MouseUp += OnMouseUp;
    }
    private void OnDisable()
    {
        _uiHandle.MouseDown -= OnMouseDown;
        _uiHandle.MouseUp -= OnMouseUp;
    }

    private void OnMouseDown()
    {
        _tackedCube = SpawnCube();
    }
    private void OnMouseUp()
    {
        _tackedCube.Kick(Vector3.forward * _cubeKickForce);
    }
    
    private Cube SpawnCube()
    {
        var cube = _fabric.CreateCubeWithRandomNumber(_spawnPoint.position);
        cube.CollisionWithSameCube += OnCollisionWith;
        
        return cube;
    }
    
    private void OnCollisionWith(Cube cube1, Cube cube2)
    {
        _cubeMerger.Merge(cube1, cube2);
    }
}