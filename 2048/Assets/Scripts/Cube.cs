using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    public event Action<Cube, Cube> CollisionWithSameCube;
    
    public int Number = 2;

    [SerializeField] private List<TMP_Text> _textFields;

    private Renderer _renderer;

    public bool IsTheSameCube(Cube otherCube)
    {
        return otherCube.Number == Number;
    }
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        
        SetNumber(Number);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            OnCollisionWithCobe(cube);
        }
    }

    private void OnCollisionWithCobe(Cube cube)
    {
        if (cube.Number == Number)
        {
            CollisionWithSameCube?.Invoke(cube, this);
        }
    }

    public void SetNumber(int number)
    {
        for (int i = 0; i < 6; i++) {
            _textFields[i].text = number.ToString();
        }
        SetColorByNUmber(number);
    }

    private void SetColorByNUmber(int number)
    {
        Color customColor = new Color(1.0f / number, 2.0f / number, 0.7f, 1.0f);
        _renderer.material.color = customColor;
    }
} 