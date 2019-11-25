using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasswordCheck : MonoBehaviour
{

    public string correctPassword;
    public int whichLvlLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPass(string s)
    {
        if(s==correctPassword)
        {
            SceneManager.LoadScene(whichLvlLoad);
        }
        else
        {
            //INCORRECT
            Debug.Log("WRONG");
        }
    }
}
