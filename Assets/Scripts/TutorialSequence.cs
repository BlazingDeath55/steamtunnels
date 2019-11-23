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
    Vector3 botPos;
    public Vector3 topPos;
    public Transform tutIcons;

    // Start is called before the first frame update
    void Start()
    {
        willLoc = transform;
        will = GetComponent<SpriteRenderer>();
        tutBox = transform.GetChild(0).GetComponent<SpriteRenderer>();
        index = 0;
        last_index = 0;
        botPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if((Input.GetAxis("Pickup1") > 0.01 && prevPickupVal1 < 0.01) || (Input.GetAxis("Pickup2") > 0.01 && prevPickupVal2 < 0.01))
        {
            NextMessage();
        }
        prevPickupVal1 = Input.GetAxis("Pickup1");
        prevPickupVal2 = Input.GetAxis("Pickup2");
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
        for (int i=0; i<tutIcons.childCount; i++)
        {
            tutIcons.GetChild(i).gameObject.SetActive(false);
        }
        tutBox.sprite = tutSeq[index];
        if(index == 1 || index == 3)
        {
            moveTop();
            if(index == 1)
            {
                tutIcons.GetChild(1).gameObject.SetActive(true);
                tutIcons.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                tutIcons.GetChild(3).gameObject.SetActive(true);
                tutIcons.GetChild(4).gameObject.SetActive(true);
                tutIcons.GetChild(5).gameObject.SetActive(true);
                tutIcons.GetChild(6).gameObject.SetActive(true);
                tutIcons.GetChild(2).gameObject.SetActive(true);
            }
        }
        else
        {
            moveBottom();
            if(index == 2)
            {
                tutIcons.GetChild(8).gameObject.SetActive(true);
            }
            else if(index == 4)
            {
                tutIcons.GetChild(7).gameObject.SetActive(true);
            }
        }
    }

    void moveTop()
    {
        transform.localPosition = topPos;
        will.flipY = true;
    }

    void moveBottom()
    {
        transform.position = botPos;
        will.flipY = false;
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
