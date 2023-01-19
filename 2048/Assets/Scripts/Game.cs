using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CubeMerger _cubeMerger;
    [SerializeField] private RectTransform _catapultLocation;
    [SerializeField] private Fabric _fabric;
    [SerializeField] private ScrollBarControl _scrollBarControl;
    [SerializeField] private Catapult _catapult;
    
    private void OnEnable()
    {
        _scrollBarControl.MouseDown += OnMouseDown;
        _scrollBarControl.MouseUp += OnMouseUp;
        _scrollBarControl.MouseMove += OnMouseMove;
    }
    private void OnDisable()
    {
        _scrollBarControl.MouseDown -= OnMouseDown;
        _scrollBarControl.MouseUp -= OnMouseUp;
        _scrollBarControl.MouseMove -= OnMouseMove;
    }

    private void OnMouseDown()
    {
        var spawnCube = SpawnCube();
        _catapult.Attach(spawnCube);
    }

    private void OnMouseUp()
    {
        _catapult.ThrowProjectile();
    }

    private void OnMouseMove(Vector3 position)
    {
        _catapult.ProjectileFollowing(position);
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