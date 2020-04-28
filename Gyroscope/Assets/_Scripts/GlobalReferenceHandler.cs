using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferenceHandler : MonoBehaviour
{
    #region singleton stuff
    //singleton stuff
    private static GlobalReferenceHandler instance;
    private GlobalReferenceHandler() { } //private constructor
    public static GlobalReferenceHandler GetInstance()
    {
        if (!instance)
            instance = FindObjectOfType<GlobalReferenceHandler>();
        return instance;
    }
    public void InitSingleton()
    {
        if (instance != null && instance != this)
            Destroy(gameObject); //prevent duplicates in scene
        else
            instance = this;
    }
    #endregion

    public FirstPersonController player;

    private void Awake()
    {
        InitSingleton();
    }


}
