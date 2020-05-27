using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraInteract : MonoBehaviour
{
    
    [Header("Interaction ray")]
    public float interactRange;
    public LayerMask whatToInteractWith;

    [SerializeField] private bool drawGizmos;

    public List<Vector3> rayOffsets;

    public void Update()
    {
        //project a raycast forward
        RaycastHit rayHit;
        bool wasHit = Physics.Raycast(transform.position, transform.forward, out rayHit, interactRange, whatToInteractWith);

        foreach(Vector3 offset in rayOffsets)
        {
            if (wasHit) break;
            wasHit = Physics.Raycast(transform.position + offset, transform.forward, out rayHit, interactRange, whatToInteractWith);
        }
        if (wasHit && rayHit.collider.CompareTag(StaticVariables.Tags.Interactable))
        {
            //get the interactable
            var interactable = rayHit.collider.GetComponent<OnClickInteractable>();

            //highlight the interactable to show the player what he/she is pointing at.
            interactable?.OnHighlight(this.gameObject);

            if (Input.GetMouseButtonDown(0))
            {
                //interact on left-click
                interactable.HandleInteract(this.gameObject);
            }
        }
    }
    public void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(this.transform.position, this.transform.forward * interactRange);
            foreach (Vector3 offset in rayOffsets)
            {
                Gizmos.DrawRay(this.transform.position + offset, this.transform.forward * interactRange);
            }
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(this.transform.position, interactRange);
        }
    }
}

