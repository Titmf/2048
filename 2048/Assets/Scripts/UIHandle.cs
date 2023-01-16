using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 _offsetDelta = Vector2.zero;
    
    public event Action MouseDown;
    public event Action<Vector2> MouseMove;
    public event Action MouseUp;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offsetDelta = Vector2.zero;
        MouseDown?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _offsetDelta = eventData.delta/100f;
        MouseMove?.Invoke(_offsetDelta);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _offsetDelta = Vector2.zero;
        MouseUp?.Invoke();
    }
}