using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Transform myDrone;
    public GameObject lightDoor;
    public float threshold;
    public bool droneInRange;

    bool open;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<Lever>().LeverTogglingAction += OpenDoor;
        open = false;
        droneInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            if(Vector2.Distance(myDrone.position, transform.position) < threshold)
            {
                droneInRange = true;
            }
            else
            {
                droneInRange = false;
            }
        }
    }

    void OpenDoor()
    {
        lightDoor.SetActive(true);
        open = true;
    }
}
