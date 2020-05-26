using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ProxyActivateColliderTrigger : MonoBehaviour
{
    public Collider colliderTarget;
    public Material matToChange;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag(StaticVariables.Tags.Player))
        colliderTarget.enabled = true;
        Debug.Log("Triggered!");
        matToChange.SetVector("MinMaxDistance", new Vector4(0.1f, 0.2f, 0, 0));
    }
}
