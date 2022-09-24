using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseScript : MonoBehaviour
{
    Rigidbody2D eraserRB;

    void Awake()
    {
        eraserRB = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with eraser");
        
    }
}
