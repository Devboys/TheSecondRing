﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportToOverworldTargetTrigger : MonoBehaviour
{
    //the target to teleport the player to
    public Transform target;
    private FirstPersonController player;

    public float transitionTime;

    public void Start()
    {
        player = FindObjectOfType<FirstPersonController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<FirstPersonController>();
            BeginTransition();
        }
    }

    private void BeginTransition()
    {
        Debug.Log("Teleporting");
        FindObjectOfType<FadeInImage>().FadeIn(false);

        player.controlEnabled = false;
        StartCoroutine(TransitionPlayer());
    }

    private void DelayedTeleport()
    {
        player.GetComponent<GravityBody>().isAttracted = true;
        player.TeleportPlayerToPosition(target.position);
        FindObjectOfType<FadeInImage>().FadeOut();
    }

    private void EndTransition()
    {
        player.controlEnabled = true;
    }

   private IEnumerator TransitionPlayer()
   {
        yield return new WaitForSeconds(transitionTime / 2);
        DelayedTeleport();
        yield return new WaitForSeconds(transitionTime / 2);
        EndTransition();
   }


}
