using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReFillScript : OnClickInteractable
{

    public ProxyActivateColliderTrigger thething;
    public override void HandleInteract(GameObject sender)
    {
        base.HandleInteract(sender);

        thething.ActivateEverything();

        Destroy(this.gameObject);
    }


}
