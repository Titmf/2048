using UnityEngine;

public class Fabric : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform spawnPoint;

    private readonly int[] _startNumber = {2,4,8,16,32,64};

    private void OnMouseUp()
    {
        cube.GetComponent<Rigidbody>().AddForce(Vector3.forward*2000f);
        cube.GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnMouseDown()
    {
        CreateCube(_startNumber[new System.Random().Next(0, _startNumber.Length)], spawnPoint);
    }

    private void CreateCube(int startNumberOfCube, Transform spawnPointOfCube)
    {
        cube = Instantiate(cube, spawnPointOfCube.position, spawnPointOfCube.rotation);
        cube.GetComponent<Cube>().number = startNumberOfCube;
        cube.name = startNumberOfCube.ToString();
        cube.GetComponent<Cube>().SetNumber(startNumberOfCube);
    }
}