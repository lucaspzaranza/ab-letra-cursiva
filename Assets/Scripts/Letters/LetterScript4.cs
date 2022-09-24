using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript4 : MonoBehaviour
{
    public bool col4 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col4 = true;
            Debug.Log("Col4");
        }
    }
}
