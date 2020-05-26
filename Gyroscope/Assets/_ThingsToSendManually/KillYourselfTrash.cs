using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillYourselfTrash : MonoBehaviour
{
    public bool pressbutton;

    public Image image;
    public AudioClip failclip;
    public AudioClip successClip;
    public AudioClip textPopUpSound;

    public bool pressed;
    public bool allowed;

    public List<GameObject> texts;

    private void Start()
    {
        foreach(var t in texts)
        {
            t.SetActive(false);
        }
    }
    void OnKYSbuttonPressed()
    {
        var s = GetComponent<AudioSource>();
        if (allowed)
        {
            pressed = true;
            s.PlayOneShot(successClip);
            image.color = Color.black;
            StartCoroutine(enableText());

            var sources = GameObject.FindObjectsOfType<AudioSource>();
            foreach (var item in sources)
            {
                if (item != s)
                {
                    Destroy(item);
                }
            }
        }
        else
        {
            s.PlayOneShot(successClip);
        }
        
    }

    IEnumerator enableText()
    {
        var s = GetComponent<AudioSource>();
        foreach (var item in texts)
        {
            yield return new WaitForSeconds(1.4f);
            s.PlayOneShot(textPopUpSound);

            item.SetActive(true);
        }
    }

    private void Update()
    {
        if (pressbutton)
        {
            OnKYSbuttonPressed();
            pressbutton = false;
        }


        //if (pressed)
        //{
           
        //    var c = image.color;

        //    c.a = Mathf.MoveTowards(c.a, 1, Time.deltaTime); //fade
        //}
    }


}
