using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoad : MonoBehaviour
{
    int scene_num;

    // Start is called before the first frame update
    void Start()
    {
        scene_num = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Pickup1") > 0.01)
        {
            SceneManager.LoadScene(scene_num);
        }
    }
}
