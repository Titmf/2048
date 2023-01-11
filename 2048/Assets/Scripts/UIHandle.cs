using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public event Action MouseDown;
    public event Action MouseMove;
    public event Action MouseUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDown?.Invoke();
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        MouseMove?.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        MouseUp?.Invoke();
    }
}