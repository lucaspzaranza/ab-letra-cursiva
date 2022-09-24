using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript6 : MonoBehaviour
{
    public bool col6 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col6 = true;
            Debug.Log("Col6");
        }
    }
}
