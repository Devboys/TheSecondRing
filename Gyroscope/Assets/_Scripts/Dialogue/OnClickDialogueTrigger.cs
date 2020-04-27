using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDialogueTrigger : OnClickInteractable
{
    public Dialogue dialogue;

    public void Start()
    {
        
    }

    public override void HandleInteract(GameObject sender)
    {
        DialogueManager.GetInstance().StartDialogue(dialogue);
    }

}
