using UnityEngine;

public class Fabric : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform spawnPoint;

    private void OnMouseDown()
    {
        Instantiate(cube, spawnPoint.position, Quaternion.identity);
    }
}
