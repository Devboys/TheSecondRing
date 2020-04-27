using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRobot : OnClickInteractable
{
    public override void HandleInteract(GameObject sender)
    {
        Debug.Log("Text here");
    }
}
