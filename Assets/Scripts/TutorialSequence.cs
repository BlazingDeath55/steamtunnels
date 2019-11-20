using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSequence : MonoBehaviour
{
    public Sprite[] tutSeq;
    Transform willLoc;
    SpriteRenderer will, tutBox;
    int last_index, index;
    float prevPickupVal1, prevPickupVal2;

    // Start is called before the first frame update
    void Start()
    {
        willLoc = transform;
        will = GetComponent<SpriteRenderer>();
        tutBox = transform.GetChild(0).GetComponent<SpriteRenderer>();
        index = 0;
        last_index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if((Input.GetAxis("Pickup1") > 0.01 && prevPickupVal1 < 0.01) || (Input.GetAxis("Pickup2") > 0.01 && prevPickupVal2 < 0.01))
        {
            NextMessage();
        }
        prevPickupVal1 = Input.GetAxis("Pickup1");
        prevPickupVal2 = Input.GetAxis("Pickup1");
    }

    void NextMessage()
    {
        index++;
        if (index < tutSeq.Length)
            UpdateSprites();
        else
            EndTutorial();
    }

    void UpdateSprites()
    {
        tutBox.sprite = tutSeq[index];
    }

    void EndTutorial()
    {
        //WRITE THIS STILL
        Drone[] drones = GameObject.FindObjectsOfType<Drone>();
        foreach( Drone d in drones)
        {
            d.tutorialFrozen = false;
        }
        gameObject.SetActive(false);
    }
}
