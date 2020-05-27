using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChildActivator : ActivateableBase
{
    private List<ActivateableBase> Children;
    void Start()
    {
        Children = GetComponentsInChildren<ActivateableBase>().Where(a => a != this).ToList();
    }

    public override void Activate(GameObject activator, float intensity)
    {
        Children.ForEach(a => a.Activate(activator, intensity));
    }

    public override void Disable()
    {
        Children.ForEach(a => a.Disable());
    }
}
