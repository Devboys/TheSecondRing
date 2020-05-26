using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlacePowerSource : MonoBehaviour
{
    public AudioSource putinSource;
    public AudioSource ChargeSource;
    public AudioClip ChargeUp;
    public AudioClip Charged;
    public AudioClip PlaceSound;
    public AudioClip stinger;
    public bool putpowerSource;

    bool isavtive;
    List<ActivatePowerwhoo> activatePowerwhoos;
    public float glowAroundSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (putpowerSource)
        {
            Activate();
            putpowerSource = false;
        }

        if (isavtive)
        {
            foreach (var item in activatePowerwhoos)
            {
                float distmult = 1;
                if (item.number > 100)
                {
                    distmult = 10;
                }
                item.number += Time.deltaTime * glowAroundSpeed * distmult;
                item.numberTwo += Time.deltaTime * glowAroundSpeed * 2 * distmult;
            }
        }
    }


    void Activate()
    {
        if (isavtive)
        {
            return;
        }

        putinSource.PlayOneShot(PlaceSound);
        ChargeSource.PlayOneShot(ChargeUp);
        isavtive = true;
        FindObjectOfType<KillYourselfTrash>().allowed = true;
        activatePowerwhoos = FindObjectsOfType<ActivatePowerwhoo>().ToList();
        StartCoroutine(lateStartCharged());
    }

    IEnumerator lateStartCharged()
    {
        yield return new WaitForSeconds(3.9f);
        putinSource.PlayOneShot(stinger);
        ChargeSource.clip = Charged;
        ChargeSource.loop = true;
        ChargeSource.Play();
    }
}
