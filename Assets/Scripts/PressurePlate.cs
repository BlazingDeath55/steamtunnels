using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{

    public UnityAction Pressure_Plate_Activated;
    public UnityAction Pressure_Plate_Deactivated;

    public int req_weight;
    public List<GameObject> objects_on_me = new List<GameObject>();
 

    public bool checkPressure() {
        int total = 0;
        foreach (GameObject b in objects_on_me) {
            total += b.GetComponent<Base_Entity>().Get_Weight();
            
        }

        bool check = total > req_weight;

        if (check)
        {
            Pressure_Plate_Activated();
        }
        else {
            Pressure_Plate_Deactivated();
        }

        return check;

        
    }

    public void addObject(GameObject b) {
        objects_on_me.Add(b);
        checkPressure();
    }

    public void removeObject(GameObject b) {
        objects_on_me.Remove(b);
        checkPressure();
    }
}
