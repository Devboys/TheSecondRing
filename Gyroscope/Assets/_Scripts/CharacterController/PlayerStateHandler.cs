using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour
{
    [SerializeField] private GameObject activatorCollider;

    public bool startsActivated = false;

    public void Awake()
    {
        activatorCollider.SetActive(startsActivated);
    }

    public void EnableActivator()
    {
        activatorCollider.SetActive(true);

    }

}
