using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSourceScript : OnClickInteractable
{
    public override void HandleInteract(GameObject sender)
    {
        base.HandleInteract(sender);

        //give player powersource
        sender.GetComponentInParent<Activator>().isActive = true;

        //remove self
        this.gameObject.SetActive(false);
    }


}
