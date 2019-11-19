using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PressurePlate myP;
    public Vector3 slideDir;
    float spacing = 0.52f;

    // Start is called before the first frame update
    void Start()
    {
        myP.Pressure_Plate_Activated += OpenDoor;
        myP.Pressure_Plate_Deactivated += CloseDoor;
        //GameObject.FindObjectOfType<Lever>().LeverTogglingAction += OpenDoor;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor() {
        this.transform.Translate(slideDir * spacing);
    }

    void CloseDoor()
    {
        this.transform.Translate(-slideDir * spacing);
    }
}
