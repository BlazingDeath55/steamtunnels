using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PressurePlate myP;

    // Start is called before the first frame update
    void Start()
    {
        myP.Pressure_Plate_Activated += OpenDoor;
        myP.Pressure_Plate_Deactivated += CloseDoor;
        GameObject.FindObjectOfType<Lever>().LeverTogglingAction += OpenDoor;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor() {
        this.transform.Rotate(Vector3.forward, 10);
    }

    void CloseDoor()
    {
        this.transform.Rotate(Vector3.forward, -10);
    }
}
