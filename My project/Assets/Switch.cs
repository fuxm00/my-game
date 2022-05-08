using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// This class enables and disables post-processing layer 
/// according to state of a toggle.
/// </summary>
public class Switch : MonoBehaviour
{
    [SerializeField] RectTransform _paddleTransform;
    [SerializeField] Image _backGroundColor;
    [SerializeField] GameObject _mainCamera;

    private PostProcessLayer _postProcessLayer;
    private Vector2 _paddlePosition;
    private Toggle _toggle;
    void Awake()
    {
        _postProcessLayer = _mainCamera.GetComponent<PostProcessLayer>();
        _toggle = gameObject.GetComponent<Toggle>();
        _paddlePosition = _paddleTransform.anchoredPosition;
        _toggle.onValueChanged.AddListener(OnChange);
        
        if (PlayerPrefs.GetInt("isON") == 1)
        {
            _toggle.isOn = true;
            OnChange(true);
        } else
        {
            _toggle.isOn = false;
            OnChange(false);
        }
    }

    public void OnChange(bool isOn)
    {
        if (isOn)
        {
            _paddleTransform.anchoredPosition = _paddlePosition * -1;
            _backGroundColor.color = Colors.BrightGreen;
            PlayerPrefs.SetInt("isON", 1);

            if (_postProcessLayer != null)
            {
                _postProcessLayer.enabled = true;
            }

        } else
        {
            _paddleTransform.anchoredPosition = _paddlePosition;
            _backGroundColor.color = Colors.Grey;
            PlayerPrefs.SetInt("isON", 0);

            if (_postProcessLayer != null)
            {
                _postProcessLayer.enabled = false;
            }
        }
    }
}
