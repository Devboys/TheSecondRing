using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEJetpack : MonoBehaviour
{
    public float speedp;
    public float minFreq;
    public float maxFreq;

    public float MaxSpeed;
    AudioSource AudioSource;

    // Update is called once per frame

    Vector3 prev = Vector3.one;
    float t;
    void Update()
    {
        //t += Time.deltaTime;
        //if (t > .2f)
        //{
        //    t = 0;
            speedp = Vector3.Distance(prev, transform.position);
            prev = transform.position;
        //}
        if (!AudioSource)
        {
            AudioSource = GetComponent<AudioSource>();
        }
        //var speed = transform.parent.GetComponent<Rigidbody>().velocity.magnitude;
        //speedp = speed;
        var norm = Mathf.Clamp01(speedp / MaxSpeed);


        AudioSource.pitch = Mathf.MoveTowards(AudioSource.pitch, Mathf.Clamp(maxFreq * norm, minFreq, maxFreq), Time.deltaTime);
        
    }
}
