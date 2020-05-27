using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Light))]
public class ChangeIntensityOnActivate : ActivateableBase
{
    private bool isActive;
    private Transform target;
    private float intensity;
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        intensity = _light.intensity;
    }

    void Update()
    {
        if (!isActive)
        {
            _light.intensity = 0;

            return;
        }
        
        var calcIntensity = intensity * (1 - Mathf.Clamp01(StaticMath.NormalizeValue(Vector3.Distance(target.position, transform.position), 5,
                                     20)));
        _light.intensity = calcIntensity;
    }

    public override void Activate(GameObject activator, float intensity)
    {
        isActive = true;
        target = activator.transform;
    }

    public override void Disable()
    {
        isActive = false;
    }
}
