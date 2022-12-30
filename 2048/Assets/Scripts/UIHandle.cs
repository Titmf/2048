using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action MouseUp;
    public event Action MouseDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDown?.Invoke();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        MouseUp?.Invoke();
    }
}