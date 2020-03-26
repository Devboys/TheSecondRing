using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    public Transform player;
    public Vector3 pos;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;
        rend.material.SetVector("_player", pos);
    }
}
