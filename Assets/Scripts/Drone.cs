﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    private bool isHoldingObject = false;
    private GameObject holdingObject;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MotionUpdate();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.gameObject.GetComponent<PickableObject>())
            {
                toggleHolding(collision.gameObject);
            }
            else if (collision.gameObject.GetComponent<PressurePlate>())
            {
                togglePressurePlate(collision.gameObject);
            }
        }
    }

    void togglePressurePlate(GameObject go) {
        
        toggleHolding(holdingObject);

        if (!isHoldingObject)
        {
            go.GetComponent<PressurePlate>().addObject(go);
        }
        else {
            go.GetComponent<PressurePlate>().removeObject(go);
        }
        
    }

    void toggleHolding(GameObject go) {

        isHoldingObject = !isHoldingObject;

        if (isHoldingObject)
        {
            go.transform.SetParent(this.transform, false);
            holdingObject = go;
        }
        else {
            go.transform.SetParent(null, true);
            holdingObject = null;
        }
        
    }

    void MotionUpdate()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Rigidbody2D rbd = GetComponent<Rigidbody2D>();
        rbd.AddForce(new Vector2(xDir, yDir) * speed);
    }

}