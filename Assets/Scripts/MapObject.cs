using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public GameObject infoCard;

    private MapManager myMap;
    private Drone myDrone; 
    private bool unlocked = false;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        myMap = GameObject.FindObjectOfType<MapManager>();
        myDrone = GameObject.FindObjectOfType<Drone>();

        myDrone.ButtonPressed += PlayLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing) {
            if (Vector3.Distance(myDrone.transform.position, this.transform.position) > myMap.GetMinimumDistance()) {
                hideInfoCard();
            }
        }

    }

    public void PlayLevel() {

        if (unlocked)
        {
            // play level 
        }
    }

    public void unlockMap() {
        unlocked = true;
    }

    public void showInfoCard() {
        isShowing = true;
        infoCard.SetActive(true);
    }

    private void hideInfoCard() {
        isShowing = false;
        infoCard.SetActive(false);
    }


}
