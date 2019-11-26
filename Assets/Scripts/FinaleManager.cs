using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinaleManager : MonoBehaviour
{
    public Lever l1, l2;
    public SpriteRenderer[] theDark;
    public SpriteMask[] masks;
    public GameObject rice, escape;


    bool l1On, l2On;
    float alphaVal;
    int which_event;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        l1.LeverTogglingAction += Lever1Toggle;
        l2.LeverTogglingAction += Lever2Toggle;
        l1On = false;
        l2On = false;
        which_event = 0;
        timer = 2;
        alphaVal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(l1On && l2On)
        {
            LightsUp();
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                switch(which_event)
                {
                    case (0):
                        rice.SetActive(true);
                        timer = 3;
                        which_event++;
                        break;
                    case (1):
                        escape.SetActive(true);
                        timer = 4;
                        which_event++;
                        break;
                    case (2):
                        Color c = theDark[0].color;
                        c.a = alphaVal;
                        theDark[0].color = c;
                        alphaVal += Time.deltaTime/2;
                        if(alphaVal >= 1)
                        {
                            NextScene();
                        }
                        break;
                }
            }
        }
    }

    void Lever1Toggle()
    {
        l1On = true;
    }

    void Lever2Toggle()
    {
        l2On = true;
    }

    void LightsUp()
    {
        foreach(SpriteRenderer spr in theDark)
        {
            spr.enabled = false;
        }
        foreach(SpriteMask m in masks)
        {
            m.enabled = false;
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(8);
    }
}
