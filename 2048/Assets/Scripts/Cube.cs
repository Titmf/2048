using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    public event Action<Cube, Cube> CollisionWithSameCube;
    
    public int number = 2;

    [SerializeField] private List<TMP_Text> textFields;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        
        SetNumber(number);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {
            OnCollisionWithCube(cube);
        }
    }

    public void SetNumber(int number)
    {
        for (int i = 0; i < 6; i++) {
            textFields[i].text = number.ToString();
        }
        SetColorByNumber(number);
    }

    private bool IsTheSameCube(Cube otherCube)
    {
        return otherCube.number == number;
    }

    private void OnCollisionWithCube(Cube cube)
    {
        if (IsTheSameCube(cube))
        {
            CollisionWithSameCube?.Invoke(cube, this);
        }
    }

    private void SetColorByNumber(int number)
    {
        Color customColor = new Color(1.0f / number, 2.0f / number, 0.7f, 1.0f);
        _renderer.material.color = customColor;
    }
} 