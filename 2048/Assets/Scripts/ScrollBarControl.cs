using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollBarControl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public event Action MouseDown;
    public event Action<Vector3> MouseMove;
    public event Action MouseUp;

    [SerializeField] private Scrollbar _scrollbar;
    
    [SerializeField] private RectTransform _handle;

    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDown?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        MouseMove?.Invoke(_handle.position);
        _scrollbar.OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        MouseUp?.Invoke();
    }
}