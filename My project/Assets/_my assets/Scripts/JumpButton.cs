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

    /// <summary>
    /// Sets _isPressed when a pointer goes up.
    /// </summary>
    /// <param name="eventData">
    /// information about an event of pressing a button
    /// </param>
    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    /// <summary>
    /// Sets _isPressed when a pointer goes down.
    /// </summary>
    /// <param name="eventData">
    /// information about an event of unpressing a button
    /// </param>
    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }
}
