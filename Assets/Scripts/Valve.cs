using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Valve : MonoBehaviour
{
    public UnityAction SteamOff, SteamOn;
    public float thresholdDistance = 4f;
    int which;

    private Drone[] myDs;

    // Start is called before the first frame update
    void Start()
    {
        myDs = GameObject.FindObjectsOfType<Drone>();
        foreach (Drone myD in myDs)
        {
            myD.ButtonPressed += OnButton;
        }
        which = 0;
    }

    void OnButton()
    {
        foreach (Drone myD in myDs)
        {
            Vector3 PosVec = this.gameObject.transform.position - myD.transform.position;
            //ONLY ACTIVATES ONCE, CANNOT BE UN-PULLED
            if (Vector3.SqrMagnitude(PosVec) <= thresholdDistance + Mathf.Pow(PosVec.z, 2))
            {
                Debug.Log("Togelled Lever");
                ToggleSprites();
                if (which == 0)
                {
                    SteamOff();
                }
                else
                {
                    SteamOn();
                }
            }
        }
    }

    void ToggleSprites()
    {
        transform.GetChild(which).gameObject.SetActive(false);
        which++;
        which %= 2;
        transform.GetChild(which).gameObject.SetActive(true);
    }
}
