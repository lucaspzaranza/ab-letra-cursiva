using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript12 : MonoBehaviour
{
    public bool col12 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col12 = true;
            Debug.Log("Col12");
        }
    }
}
