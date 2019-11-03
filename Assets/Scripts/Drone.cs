using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drone : MonoBehaviour
{

    public UnityAction ButtonPressed;
    public string horizontalAxis, verticalAxis;
    private bool isHoldingObject = false;
    private GameObject holdingObject;
    public float speed = 50f, maxSpeed = 10, timeframe = 7, thresholdSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(holdingObject);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(!isHoldingObject)
                ButtonPressed();
            toggleHolding();
        }
    }

    private void FixedUpdate()
    {
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
        Vector2 inputVector = new Vector2(xDir, yDir);
        /*
        rbd.AddForce(inputVector * speed);
        //CAPS VELOCITY
        if (rbd.velocity.magnitude > maxSpeed)
        {
            rbd.velocity = rbd.velocity.normalized * maxSpeed;
        }
        //DECCELERATES
        if(inputVector.magnitude < 0.1f)
        {
          //  Debug.Log(rbd.velocity);
            rbd.AddForce(-rbd.velocity * timeframe);

            if (rbd.velocity.magnitude <= thresholdSpeed) {
                rbd.velocity = Vector2.zero;
            }
        }
        */
        rbd.velocity = inputVector * maxSpeed;

    }

}
