using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivateableBase : MonoBehaviour
{
    public abstract void Activate(GameObject activator);
    public abstract void Disable();
    
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    Activate(other.gameObject);
        //}
    }
    
    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    Disable();
        //}
    }
}
