using Unity.VisualScripting;

using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    private Rigidbody _rigidbody1Cube;
    private Rigidbody _rigidbody2Cube;

    public void Merge(Cube cube1, Cube cube2)
    {
        cube1.Freeze();
        cube2.Freeze();
        
        MoveToCenterBetween(cube1.transform, cube2.transform);
        
        cube2.SetNumber(cube2.Number * 2);
        
        Destroy(cube1.gameObject);
    }

    private void MoveToCenterBetween(Transform cube1, Transform cube2)
    {
        var center = GetCenterBetween(cube1, cube2);
        
        cube1.position = center;
        cube2.position = center;
    }

    private Vector3 GetCenterBetween(Transform cube1, Transform cube2)
    {
        var vector = cube1.position - cube2.position;
        
        return vector * 0.5f;
    }
}