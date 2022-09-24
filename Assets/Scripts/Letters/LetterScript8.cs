using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript8 : MonoBehaviour
{
    public bool col8 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col8 = true;
            Debug.Log("Col8");
        }
    }
}
