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
        SetNumberAndColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cube") && this.name == collision.gameObject.name)
        {
            numberOfCube *= 2;
            var collisionPoint = collision.transform.position;
            Destroy(collision.gameObject);
            cube.name = numberOfCube.ToString();
            SetNumberAndColor();
            _rigidOfCube.AddForce(collisionPoint+Vector3.up*200f);
        }
    }
    
    private void SetNumberAndColor()
    {
        for (int i = 0; i < 6; i++) {
            textNumbers[i].text = numberOfCube.ToString();
        }
        Color customColor = new Color(1.0f/numberOfCube, 2.0f/numberOfCube, 0.7f, 1.0f);
        _rendererOfCube.material.color= customColor;
    }
} 