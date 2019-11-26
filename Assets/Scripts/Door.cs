using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PressurePlate myP;
    public Vector3 slideDir;
    float spacing = 0.52f;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        myP.Pressure_Plate_Activated += OpenDoor;
        myP.Pressure_Plate_Deactivated += CloseDoor;
        //GameObject.FindObjectOfType<Lever>().LeverTogglingAction += OpenDoor;
        aud = GetComponent<AudioSource>();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor() {
        this.transform.Translate(slideDir * spacing);
        aud.Play();

    }

    void CloseDoor()
    {
        this.transform.Translate(-slideDir * spacing);
        aud.Play();
    }
}
