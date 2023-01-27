using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggBehavior : MonoBehaviour
{
    private Vector2 _initialScale;
    private Vector2 _scaleValue = new Vector2(.9f, .9f);
    [SerializeField] private Text displayTap;
    private int _tapCount;

    private void Start()
    {
        _initialScale = transform.localScale;

        if (PlayerPrefs.HasKey("remainingTaps"))
        {
            _tapCount = PlayerPrefs.GetInt("remainingTaps");
            CheckValue();
        }
        else
        {
            _tapCount = 100;
            displayTap.text = _tapCount.ToString();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale *= _scaleValue;
            _tapCount--;
            CheckValue();
            PlayerPrefs.SetInt("remainingTaps", _tapCount);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = _initialScale;
        }
    }

    void CheckValue()
    {
        if (_tapCount > 0)
        {
            displayTap.text = _tapCount.ToString();
        }
        else if (_tapCount <= 0)
        {
            _tapCount = 0;
            displayTap.text = "So, what?";
        }
    }
}
