using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript1 : MonoBehaviour
{
    public bool col1 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col1 = true;
            Debug.Log("Col1");
        }
    }
}
