using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEJetpack : MonoBehaviour
{
    public float speedp;
    public float minFreq;
    public float maxFreq;

    public float MaxSpeed;
    AudioSource audioSource;

    // Update is called once per frame

    Vector3 prev = Vector3.one;
    float t;

    void Update()
    {
        speedp = Vector3.Distance(prev, transform.position);
        prev = transform.position;
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }

        var norm = Mathf.Clamp01(speedp / MaxSpeed);


        if (audioSource)
        {
            audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, Mathf.Clamp(maxFreq * norm, minFreq, maxFreq), Time.deltaTime);
        }
        
    }
}
