using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Valve : MonoBehaviour
{
    public UnityAction SteamOff, SteamOn;
    public float thresholdDistance = 4f;
    int which;
    AudioSource aud;

    public Drone myD;

    // Start is called before the first frame update
    void Start()
    {
        myD.ButtonPressed += OnButton;
        which = 0;
        aud = GetComponent<AudioSource>();
    }

    void OnButton()
    {
        Vector3 PosVec = this.gameObject.transform.position - myD.transform.position;
        //ONLY ACTIVATES ONCE, CANNOT BE UN-PULLED
        if (Vector3.SqrMagnitude(PosVec) <= thresholdDistance + Mathf.Pow(PosVec.z, 2))
        {
            Debug.Log("Togelled Lever");  
            if (which == 0)
            {
                SteamOff();
            }
            else
            {
                SteamOn();
            }
            ToggleSprites();
        }
    }

    void ToggleSprites()
    {
        transform.GetChild(which).gameObject.SetActive(false);
        which++;
        which %= 2;
        transform.GetChild(which).gameObject.SetActive(true);
        aud.Play();
    }
}
