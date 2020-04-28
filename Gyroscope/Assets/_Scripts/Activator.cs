using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        { 
            other.GetComponent<ActivateableBase>()?.Activate(gameObject);
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
