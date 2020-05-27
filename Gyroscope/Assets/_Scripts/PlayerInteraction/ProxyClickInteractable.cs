using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyClickInteractable : OnClickInteractable
{
    public OnClickInteractable target;

    bool ChangeMatColorOnHighlight;
    // Start is called before the first frame update
    void Start()
    {
        this.OnInteractEvent += () => target.HandleInteract(this.gameObject);
    }

}
