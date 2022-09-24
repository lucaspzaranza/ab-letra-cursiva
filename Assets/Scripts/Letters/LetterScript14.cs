using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript14 : MonoBehaviour
{
    public bool col14 = false; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            col14 = true;
            Debug.Log("Col14");
        }
    }
}
