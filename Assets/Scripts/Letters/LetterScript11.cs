using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript11 : MonoBehaviour
{
    public bool col11 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col11 = true;
            Debug.Log("Col11");
        }
    }
}
