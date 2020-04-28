using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Tooltip("The object that will trigger interactions for this object")]
    public OnClickInteractable triggerObject;

    public void Awake()
    {
        triggerObject.OnInteractEvent += () => HandleInteract();
        
    }

    public void HandleInteract()
    {
        if (gameObject.activeInHierarchy)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
    }
}
