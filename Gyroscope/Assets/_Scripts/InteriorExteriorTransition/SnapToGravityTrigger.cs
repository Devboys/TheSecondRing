using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapToGravityTrigger : MonoBehaviour
{
    //the target to teleport the player to
    public Transform target;
    public FirstPersonController player;

    public float transitionTime;

    public void OnTriggerEnter(Collider other)
    {

        if (player.GetComponent<GravityBody>().isAttracted == true) {
            player.GetComponent<GravityBody>().isAttracted = false;
        }
        else
        {
            player.GetComponent<GravityBody>().isAttracted = true;
        }

    }

    private void BeginTransition()
    {
        Debug.Log("Teleporting");
        player.controlEnabled = false;
        player.GetComponent<GravityBody>().isAttracted = true;
        player.TeleportPlayerToPosition(target.position);
        StartCoroutine(TransitionPlayer());
    }

    private void EndTransition()
    {
        player.controlEnabled = true;
    }

   private IEnumerator TransitionPlayer()
   {
        yield return new WaitForSeconds(transitionTime);
        EndTransition();
   }


}
