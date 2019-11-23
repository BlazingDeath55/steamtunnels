using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drone : MonoBehaviour
{

    public UnityAction ButtonPressed;
    public string horizontalAxis, verticalAxis, pickupAxis;
    private bool isHoldingObject = false;
    private GameObject holdingObject;
    public float  maxSpeed = 10;
    float prevPickupVal;

    public bool tutorialFrozen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialFrozen)
        {
            //Debug.Log(holdingObject);
            if (Input.GetAxis(pickupAxis) > 0.01 && prevPickupVal < 0.01)
            {
                if(!isHoldingObject)
                    ButtonPressed();
                toggleHolding();
            }
            prevPickupVal = Input.GetAxis(pickupAxis);
        }
    }

    private void FixedUpdate()
    {
        if(!tutorialFrozen)
            MotionUpdate();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        holdingObject = collision.gameObject;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        holdingObject = null;
    }


    void CheckPressurePlate() {
        this.transform.GetComponentInChildren<PickableObject>().CheckPlateBelow();
    }

    void toggleHolding() {
        
        if (isHoldingObject)
        {
            CheckPressurePlate();
            this.transform.GetComponentInChildren<PickableObject>().transform.SetParent(null, true);
            holdingObject = null;
            isHoldingObject = !isHoldingObject;

        }
        else
        {
            if (holdingObject != null && holdingObject.GetComponent<PickableObject>()) {
                holdingObject.transform.SetParent(this.transform, true);
                Vector3 myT = this.transform.position;
                holdingObject.transform.position = new Vector3(myT.x, myT.y, myT.z + 2);
                isHoldingObject = !isHoldingObject;
                CheckPressurePlate();
            }
        }
    }

    void MotionUpdate()
    {
        float xDir = Input.GetAxis(horizontalAxis);
        float yDir = Input.GetAxis(verticalAxis);
        Rigidbody2D rbd = GetComponent<Rigidbody2D>();
        Vector2 inputVector = new Vector2(xDir, yDir).normalized;
        rbd.velocity = inputVector * maxSpeed;
    }

}
