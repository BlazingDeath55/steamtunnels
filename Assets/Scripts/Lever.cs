using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{

    public UnityAction LeverTogglingAction;
    public float thresholdDistance = 4f;

    private Drone myD;

    // Start is called before the first frame update
    void Start()
    {

        myD = GameObject.FindObjectOfType<Drone>();
        myD.ButtonPressed += OnButton;

    }

    void OnButton() {
        Vector3 PosVec = this.gameObject.transform.position - myD.transform.position;
        if (Vector3.SqrMagnitude(PosVec) <= thresholdDistance + Mathf.Pow(PosVec.z, 2)) {
            Debug.Log("Togelled Lever");
            LeverTogglingAction();           
        }
    }

}
