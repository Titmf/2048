using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] private Rigidbody cubeRigidbody;
        
    private void Start()
    {
        cubeRigidbody.AddForce(Vector3.forward*1000f);
    }
}