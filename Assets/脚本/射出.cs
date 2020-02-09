using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 射出 : MonoBehaviour
{
    public LineRenderer line1;
    public GameObject A, B;
    public Vector3 MousePosition;
    public int 钩爪射出 = 0,c=0;
    public float b = 1f,距离,极限距离 = 7f;
    public Camera maincamera;
    public bool pd = false;
    void Start()
    {
        B.gameObject.SetActive(false);

    }
    void Update()
    {
        MousePosition = Input.mousePosition;
        if (Input.GetKeyDown("w")&& 钩爪射出 == 0) 
        {
            B.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            B.gameObject.SetActive(true);
            B.transform.position = A.transform.position;
            B.GetComponent<Rigidbody2D>().AddForce(b*(maincamera.ScreenToWorldPoint(MousePosition)-B.transform.position).normalized,ForceMode2D.Impulse);
            钩爪射出 = 1;
        }
        if (钩爪射出 == 1)
        {
            line1.enabled = true;
            距离 = Mathf.Sqrt(Mathf.Pow(A.transform.position.x - B.transform.position.x, 2)+Mathf.Pow(A.transform.position.y-B.transform.position.y,2));
            line1.SetPosition(0, A.transform.position);
            line1.SetPosition(1, B.transform.position);
            if(距离>=极限距离)c = 1;
        }
        if (Input.GetKeyDown("q")) 钩爪射出 = 0;
        if (钩爪射出 == 0)
        {
            距离 = 0f;
            B.gameObject.SetActive(false);
            line1.enabled = false;
            碰撞.pz = false;
            c = 0;
            B.GetComponent<DistanceJoint2D>().distance = 极限距离;
            pd = false;
            B.GetComponent<DistanceJoint2D>().enabled = false;
        }
        
        if(c==1)
        {
            B.GetComponent<DistanceJoint2D>().enabled = true;
            A.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            if (碰撞.pz == true)
            {
                B.GetComponent<DistanceJoint2D>().enabled = false;
                碰撞.撞上 = true;
                if (this.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0)||距离>=极限距离)
                {
                    if (pd == false)
                    {
                        B.GetComponent<DistanceJoint2D>().distance = 极限距离;
                        pd = true;
                    }
                    
                    B.GetComponent<DistanceJoint2D>().enabled = true;
                }
                碰撞.pz = false;
            }
            c = 0;
        }
            
        
        
    }
    
}