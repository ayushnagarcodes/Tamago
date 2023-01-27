using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggBehavior : MonoBehaviour
{
    private Vector2 _initialScale;
    private Vector2 _scaleValue = new Vector2(.8f, .8f);
    [SerializeField] private Text displayTap;
    private int _tapCount = 100;

    private void Start()
    {
        _initialScale = transform.localScale;
        displayTap.text = _tapCount.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localScale *= _scaleValue;
            _tapCount--;
            displayTap.text = _tapCount.ToString();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = _initialScale;
        }
    }
}
