using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<Lever>().LeverTogglingAction += OpenDoor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
