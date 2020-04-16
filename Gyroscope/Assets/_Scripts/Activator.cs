using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      other.GetComponent<ActivateableBase>()?.Activate(gameObject);
   }
}
