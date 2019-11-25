using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSys : MonoBehaviour
{

    public Valve myV;

    // Start is called before the first frame update
    void Start()
    {
        myV.SteamOff += ToggleOff;
        myV.SteamOn += ToggleOn;
    }

    void ToggleOff()
    {
        Debug.Log("Steam OFF");
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void ToggleOn()
    {
        Debug.Log("Steam ON");
        transform.GetChild(0).gameObject.SetActive(true);
    }

}
