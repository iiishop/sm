using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Vector2 v2,v3;
    public int jump=0;
    public Camera maincamera;
    public float mouseposition;
    public int a = 0;
 
    void Start()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        
        
    }
    void Update()
    {
        mouseposition = maincamera.ScreenToWorldPoint(Input.mousePosition).x;
        if (mouseposition - this.transform.position.x >= 0) { this.transform.localEulerAngles = new Vector3(0, 180, 0); a = 1; }
        else { this.transform.localEulerAngles = new Vector3(0, 0, 0); a = 0; }
        if (Input.GetKey("d")&&a==0)
        {
            transform.Translate(v2);
            //GetComponent<Rigidbody2D>().AddForce(v2);
        }
        else if(Input.GetKey("a")&&a==0)
        {
            transform.Translate(-v2);
            //GetComponent<Rigidbody2D>().AddForce(-v2);
        }
        else if (Input.GetKey("a") && a == 1)
        {
            transform.Translate(v2);
            //GetComponent<Rigidbody2D>().AddForce(-v2);
        }
        else if (Input.GetKey("d") && a == 1)
        {
            transform.Translate(-v2);
            //GetComponent<Rigidbody2D>().AddForce(v2);
        }
        if(Input.GetKey("space")&&jump==0)
        {
            jump++;
            if(Input.GetKeyDown("space"))GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().AddForce(v3);
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y == 0) jump = 0;
        //GetComponent<Rigidbody2D>().velocity = new Vector2();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    
}
