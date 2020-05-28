using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSourceScript : OnClickInteractable
{

    public AudioSource externalASource;
    public AudioClip ambienceSound;
    public AudioClip pickupSound;

    public void Start()
    {
        externalASource.clip = ambienceSound;
        externalASource.loop = true;
        externalASource.Play();
    }

    public override void HandleInteract(GameObject sender)
    {
        base.HandleInteract(sender);

        if (externalASource)
        {
            externalASource.loop = false;
            externalASource.clip = pickupSound;
            externalASource.Play();
        }
        //give player powersource
        sender.GetComponentInParent<PlayerStateHandler>().EnableActivator();

        //remove self
        this.gameObject.SetActive(false);
    }


}
