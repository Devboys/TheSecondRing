using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReActivatePowerScript : OnClickInteractable
{
    public override void HandleInteract(GameObject sender)
    {
        base.HandleInteract(sender);

        //give player powersource
        sender.GetComponentInParent<PlayerStateHandler>().EnableActivator();

        //remove self
        this.gameObject.SetActive(false);
    }


}
