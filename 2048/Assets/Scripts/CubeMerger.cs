using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    private static Vector3 _centerBetweenCubes;
    
    private static Rigidbody _rigidbody1Cube;
    
    private void Awake()
    {
        Cube.CollisionWithSameCube += Merge;
    }

    private void Merge(Cube cube1,Cube cube2)
    {
        CalculateCenterBetweenCubes(cube1, cube2);
        MoveCubesToCenterBetweenThem(cube1,cube2);
        Destroy(cube1);
    }

    private static void MoveCubesToCenterBetweenThem(Component cube1,Component cube2)
    {   
        _rigidbody1Cube = cube1.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
        _rigidbody1Cube.isKinematic = true;
        _rigidbody1Cube.detectCollisions = false;
        cube1.transform.position = _centerBetweenCubes;
        cube2.transform.position = _centerBetweenCubes;
    }

    private void CalculateCenterBetweenCubes(Component cube1, Component cube2)
    {
        _centerBetweenCubes = (cube1.transform.position - cube2.transform.position)/2;
    }
}
