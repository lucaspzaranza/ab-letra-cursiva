using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript7 : MonoBehaviour
{
    public bool col7 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col7 = true;
            Debug.Log("Col7");
        }
    }
}
