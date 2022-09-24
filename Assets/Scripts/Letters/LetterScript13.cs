using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript13 : MonoBehaviour
{
    public bool col13 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col13 = true;
            Debug.Log("Col13");
        }
    }
}
