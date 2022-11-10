using UnityEngine;
using UnityEngine.UI;


public class ScrollBarScript : MonoBehaviour
{
    public Scrollbar scrollbar;
 
    void Start()
    {
        scrollbar.onValueChanged.AddListener(ScrollbarCallback);
    }
 
    void ScrollbarCallback(float value)
    {
        Debug.Log(value);
    }
    
}
