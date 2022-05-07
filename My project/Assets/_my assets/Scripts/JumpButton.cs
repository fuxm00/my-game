using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class represents jump button.
/// </summary>
public class JumpButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool _isPressed;
    public bool IsPressed
    {
        get
        {
            return _isPressed;
        }
        set
        {
            _isPressed = value;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }
}
