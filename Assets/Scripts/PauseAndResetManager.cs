using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndResetManager : MonoBehaviour
{
    float prevButton, currButton;
    bool isMenuOn;
    SpriteRenderer menu;

    Drone[] drones;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOn = false;
        prevButton = 0f;
        menu = GetComponent<SpriteRenderer>();
        drones = FindObjectsOfType<Drone>();
    }

    // Update is called once per frame
    void Update()
    {
        currButton = Input.GetAxis("PauseButton");
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
        if(currButton > 0.01 && prevButton < 0.01)
        {
            Debug.Log("PAUSE");
            if(isMenuOn)
            {
                MenuOff();
            }
            else
            {
                MenuOn();
            }
            isMenuOn = !isMenuOn;
        }
        prevButton = currButton;
    }

    void MenuOn()
    {
        menu.enabled = true;
        foreach(Drone d in drones)
        {
            d.tutorialFrozen = true;
        }
    }

    void MenuOff()
    {
        menu.enabled = false;
        foreach (Drone d in drones)
        {
            d.tutorialFrozen = false;
        }
    }

    void ResetLevel()
    {
        Debug.Log("RESET");
        Scene curr = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curr.buildIndex);
    }
}
