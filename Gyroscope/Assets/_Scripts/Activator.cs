using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isActive = false;

    public float currentIntensity = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        { 
            other.GetComponent<ActivateableBase>()?.Activate(gameObject, currentIntensity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            other.GetComponent<ActivateableBase>()?.Disable();
        }
    }
}
