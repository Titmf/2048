using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeInfo : MonoBehaviour
{
    public int numberOfCube = 2;
    [SerializeField] private List<TMP_Text> textNumbers;
    [SerializeField] private GameObject cube;

    private Renderer _rendererOfCube;
    private Rigidbody _rigidOfCube;

    private static readonly int Color2 = Shader.PropertyToID("_Color2");

    private void Start()
    {
        _rigidOfCube = cube.GetComponent<Rigidbody>();
        _rendererOfCube = GetComponent<Renderer>();
        _rigidOfCube.useGravity = false;
        SetNumber();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube") && this.name == collision.gameObject.name)
        {
            numberOfCube *= 2;
            var collisionPoint = collision.transform.position;
            Destroy(collision.gameObject);
            cube.GetComponent<CubeInfo>().numberOfCube = numberOfCube;
            cube.name = numberOfCube.ToString();
            SetNumber();
            _rigidOfCube.AddForce(collisionPoint+Vector3.up*200f);
            _rendererOfCube.material.SetColor(Color2, Color.red);
        }
    }
    
    private void SetNumber()
    {
        for (int i = 0; i < 6; i++) {
            textNumbers[i].text = numberOfCube.ToString();
        }
    }
} 