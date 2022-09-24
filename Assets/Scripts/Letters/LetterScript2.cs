using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript2 : MonoBehaviour
{
    public bool col2 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col2 = true;
            Debug.Log("Col2");
        }
    }
}
