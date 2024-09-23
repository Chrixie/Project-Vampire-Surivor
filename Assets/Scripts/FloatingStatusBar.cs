using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingStatusBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    private Transform cameraStatusBar;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        cameraStatusBar = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void Update()
    {
        transform.rotation = cameraStatusBar.transform.rotation;
    }
}
