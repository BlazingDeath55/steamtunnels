using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public MapObject[] MapsInLevels;
    public float RangeToShow = 5f;
    public Drone myDrone;

    private MapObject closest;
    private int numberOfUnlockedLevels = 1; 

    void Start()
    {
        if (PlayerPrefs.HasKey("unlockedLevels"))
        {
            numberOfUnlockedLevels = PlayerPrefs.GetInt("unlockedLevels");
        }

        myDrone.ButtonPressed += DisplayMapCard;
        updateLevels();
        InvokeRepeating("refreshClosestMap", 0.05f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayMapCard() {
        //Debug.Log(Vector3.Distance(closest.transform.position, myDrone.transform.position));
        if (Vector3.Distance(closest.transform.position, myDrone.transform.position) < RangeToShow) {
            closest.showInfoCard();
        }
    }

    public void updateLevels() {
        for (int i = 0; i < numberOfUnlockedLevels; i++) {
            MapsInLevels[i].unlockMap();
        } 
    }

    private void refreshClosestMap() {
        float minDist = 0;
        foreach (MapObject m in MapsInLevels) {
            float dist = Vector3.SqrMagnitude(m.transform.position - myDrone.transform.position);
            if (minDist == 0 || dist < minDist) {
                minDist = dist;
                closest = m;
            }
        }
    }

    public float GetMinimumDistance() {
        return RangeToShow;
    }
}
