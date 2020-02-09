using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotate : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(Vector2.up * speed);
    }
}
