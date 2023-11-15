using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 mousePos;
    private Rigidbody2D rb;
    private Lord lord;
    private Vector3 firstClickedPosition;
    private Vector3 worldPosition;
    void Start()
    {
    rb=GetComponent<Rigidbody2D>();
    lord=GetComponent<Lord>();
    firstClickedPosition = Vector3.zero;
    worldPosition = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstClickedPosition = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(0))
         {
            Move();   
            
         }else
         {
        rb.velocity=Vector2.zero;
        }
    }
    private void Move(){
        
        worldPosition = Input.mousePosition;
        
        
        Vector3 difference=worldPosition-firstClickedPosition;
        difference.Normalize();
        
        rb.velocity=new Vector2(difference.x,difference.y)*lord.speed;

    }

}