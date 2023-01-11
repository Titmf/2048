using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    public event Action<Cube, Cube> CollisionWithSameCube;

    public int Number { get; private set; } = 2;

    [SerializeField] private List<TMP_Text> _textFields;
    [SerializeField] private Rigidbody _rigidbody;
    
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        
        SetNumber(Number);
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
        Number = number;
        
        for (var i = 0; i < 6; i++) {
            _textFields[i].text = number.ToString();
        }
        
        SetColorByNumber(number);
    }

    public void Freeze()
    {
        _rigidbody.isKinematic = true;
    }

    public void Kick(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
        _rigidbody.useGravity = true;
    } 
    
    private bool IsTheSameCube(Cube otherCube)
    {
        return otherCube.Number == Number;
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
        var customColor = new Color(1.0f / number, 2.0f / number, 0.7f, 1.0f);
        _renderer.material.color = customColor;
    }
} 