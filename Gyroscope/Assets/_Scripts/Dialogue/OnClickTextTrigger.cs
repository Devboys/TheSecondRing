using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTextTrigger : OnClickInteractable
{

    public SingleText singleText;

    public override void HandleInteract(GameObject sender)
    {
        DialogueManager.GetInstance().DisplayText(singleText);
    }

}
