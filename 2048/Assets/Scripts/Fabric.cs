using UnityEngine;

public class Fabric : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int[] startNumber = {2,4,8,16,32,64};

    private void Start()
    {
        CreateCube(2, spawnPoint);
    }
    
    private void OnMouseUp()
    {
        cube.GetComponent<Rigidbody>().AddForce(Vector3.forward*2000f);
        cube.GetComponent<Rigidbody>().useGravity = true;
        CreateCube(startNumber[new System.Random().Next(0, startNumber.Length)], spawnPoint);
    }

    private void CreateCube(int startNumberOfCube, Transform spawnPointOfCube)
    {
        cube = Instantiate(cube, spawnPointOfCube.position, transform.rotation.normalized);
        cube.GetComponent<CubeInfo>().numberOfCube = startNumberOfCube;
        cube.name = startNumberOfCube.ToString();
    }
}