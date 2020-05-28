using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDialogueTrigger : OnClickInteractable
{
    public Dialogue dialogue;
    public AudioClip soundToPlay;
    AudioSource aSource;


    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        if (aSource)
        {
            aSource.clip = soundToPlay;
        }
    }

    public override void HandleInteract(GameObject sender)
    {
        bool wasLocked = DialogueManager.GetInstance().StartDialogue(dialogue);

        if (aSource != null && !wasLocked)
        {
            aSource.Play();
        }
    }

}
