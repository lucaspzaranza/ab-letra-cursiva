using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript9 : MonoBehaviour
{
    public bool col9 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col9 = true;
            Debug.Log("Col9");
        }
    }
}
