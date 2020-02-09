using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 碰撞 : MonoBehaviour
{
    public GameObject A;
    public string g;
    public float b = 15f;
    public static bool pz=false,撞上=false;
    public bool 撞上状态=true,碰撞状态=false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int d = 0;
        g = collision.gameObject.name;
        if (g == A.name) { d = 1;Debug.Log("1"); return;  }
        for (int i = 0; i <10; i++)
        {
            if (g==获取子孙.c[i]) { d = 1; Debug.Log("1"); return; }
        }
        if (d == 0)
        {
            pz = true;
            碰撞状态 = true;
            Debug.Log("0");
            if(撞上==true)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                A.GetComponent<Rigidbody2D>().AddForce(b * (this.transform.position - A.transform.position).normalized, ForceMode2D.Impulse);
                撞上 = false;
                撞上状态 = false;
            }
        }
    }
}
