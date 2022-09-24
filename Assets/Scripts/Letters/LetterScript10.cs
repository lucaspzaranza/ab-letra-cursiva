using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript10 : MonoBehaviour
{
    public bool col10 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col10 = true;
            Debug.Log("Col10");
        }
    }
}
