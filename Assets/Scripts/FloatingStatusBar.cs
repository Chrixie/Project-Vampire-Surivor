using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingStatusBar : MonoBehaviour
{

    [SerializeField] public Slider slider;
    private Transform cameraStatusBar;
    [SerializeField] private Vector3 offset;

    public void Start()
    {
        cameraStatusBar = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }




    public void UpdateXpBar(int currentValue, int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    public void UpdateStatusBar(int currentValue, int maxValue)
    {
        slider.value = (float)currentValue / (float)maxValue;
    }


    void Update()
    {
        transform.rotation = cameraStatusBar.transform.rotation;
    }
}
