using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript5 : MonoBehaviour
{
    public bool col5 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col5 = true;
            Debug.Log("Col5");
        }
    }
}
