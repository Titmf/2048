using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    public Vector3 centerBetweenCubes;

    private Rigidbody _rigidbody1Cube;
    private Rigidbody _rigidbody2Cube;
    
    private void Awake()
    {
        Cube.CollisionWithSameCube += Merge;
    }

    private void Merge(Cube cube1,Cube cube2)
    {
        CalculateCenterBetweenCubes(cube1, cube2);
        MoveCubesToCenterBetweenThem(cube1,cube2);
        cube2.SetNumber(cube2.number*2);
        Destroy(cube1.GameObject());
    }

    private void MoveCubesToCenterBetweenThem(Component cube1,Component cube2)
    {   
        _rigidbody1Cube = cube1.GetComponentInParent(typeof(Rigidbody)) as Rigidbody;
        _rigidbody1Cube.isKinematic = true;
        _rigidbody2Cube.isKinematic = true;
        cube1.GetComponentInParent<Collider>().enabled = false;
        cube1.transform.position = centerBetweenCubes;
        cube2.transform.position = centerBetweenCubes;
    }

    private void CalculateCenterBetweenCubes(Component cube1, Component cube2)
    {
        centerBetweenCubes = (cube1.transform.position - cube2.transform.position)/2;
    }
}