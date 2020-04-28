using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour
{
    [SerializeField] private GameObject activatorCollider;

    public void Awake()
    {
        activatorCollider.SetActive(false);
    }

    public void EnableActivator()
    {
        activatorCollider.SetActive(true);
    }


}
