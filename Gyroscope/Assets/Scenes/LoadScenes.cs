using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public string [] sceneName;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 1; i < 7; i++)
        {
            SceneManager.LoadScene((i), LoadSceneMode.Additive);
            print(i);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
