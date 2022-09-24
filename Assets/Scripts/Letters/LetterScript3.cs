using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript3 : MonoBehaviour
{
    public bool col3 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col3 = true;
            Debug.Log("Col3");
        }
    }
}
