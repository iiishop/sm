using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 获取子孙 : MonoBehaviour
{
    public static string[] c = new string[10];
    public int f = 0;
   
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            c[f]=transform.GetChild(i).name;f++;
            for(int j=0;j<transform.GetChild(i).childCount;j++)
            {
                c[f]=transform.GetChild(i).GetChild(j).name;
                f++;
            }
        }
    }
}
