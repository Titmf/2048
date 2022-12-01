using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class CubeInfo : MonoBehaviour
{
    private Transform _collisionPoint;
    public int numberOfCube = 2;
    [SerializeField] private GameObject cube;
    [SerializeField] private Rigidbody cubeRigidbody;
    
    //shit code
    [SerializeField] private TMP_Text text0Number;
    [SerializeField] private TMP_Text text1Number;
    [SerializeField] private TMP_Text text2Number;
    [SerializeField] private TMP_Text text3Number;
    [SerializeField] private TMP_Text text4Number;
    [SerializeField] private TMP_Text text5Number;
    
    private void Start()
    {
        //cubeRigidbody.AddForce(Vector3.forward*1000f);
        SetNumber();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube") && this.name == collision.gameObject.name)
        {
            numberOfCube *= 2;
            _collisionPoint = collision.transform;
            Destroy(collision.collider.gameObject);
            cube = Instantiate(cube, _collisionPoint.position, transform.rotation);
            cube.GetComponent<CubeInfo>().numberOfCube = numberOfCube;
            cube.name = numberOfCube.ToString();
            SetNumber();
        }
    }
    
    //shit code again
    private void SetNumber()
    {
        text0Number.text = numberOfCube.ToString();
        text1Number.text = numberOfCube.ToString();
        text2Number.text = numberOfCube.ToString();
        text3Number.text = numberOfCube.ToString();
        text4Number.text = numberOfCube.ToString();
        text5Number.text = numberOfCube.ToString();
    }
}        