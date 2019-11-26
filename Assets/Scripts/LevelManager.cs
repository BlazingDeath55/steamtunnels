using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int scene;
    public ExitDoor[] exits;

    // Start is called before the first frame update
    void Start()
    {
        //exits = GetComponentsInChildren<ExitDoor>(true);
    }

    // Update is called once per frame
    void Update()
    {
        bool nextLevel = true;
        foreach(ExitDoor exit in exits)
        {
            if(!exit.droneInRange)
            {
                nextLevel = false;
            }
        }
        if(nextLevel)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(scene);
    }
}
