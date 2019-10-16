using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public float thresholdDist = 1f;
    public GameObject pressurePlate;
    bool isOnPlate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PressurePlate>()) {
            pressurePlate = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PressurePlate>())
        {
            pressurePlate = null;
        }
    }

    public void CheckPlateBelow() {
        //Debug.Log("Called in object");
        if (pressurePlate != null) {
            if (!isOnPlate)
            {
                pressurePlate.GetComponent<PressurePlate>().addObject(this.gameObject);
            }
            else {
                pressurePlate.GetComponent<PressurePlate>().removeObject(this.gameObject);
            }

            isOnPlate = !isOnPlate;
        }
    }
}
