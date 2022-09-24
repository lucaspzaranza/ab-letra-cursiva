using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class LetterScript : MonoBehaviour
{
    public static event Action OnErasedAll;
    public static event Action BeginErasing;

    [SerializeField] private List<LetterCollider> _letterColliders;
    [SerializeField] private Button _nextStageButton;

    private int _checkedCounter;

    private void Start()
    {
        LetterCollider.OnLetterColliderChecked += HandleOnLetterColliderChecked;
    }

    public void HandleOnLetterColliderChecked()
    {
        _checkedCounter++;

        if(_checkedCounter == _letterColliders.Count)
        {
            print("Letters traces completed!");
            _nextStageButton.gameObject.SetActive(true);
        }
    }

    public void EraseAll()
    {
        BeginErasing?.Invoke();
        GameObject[] objects;
        objects = GameObject.FindGameObjectsWithTag("Player");
        if(objects.Length == 0) Debug.Log("No objects found!");
        else
        {
            _checkedCounter = 0;
            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }

            foreach (var letterCollider in _letterColliders)
            {
                letterCollider.gameObject.SetActive(true);
            }

            _nextStageButton.gameObject.SetActive(false);
            OnErasedAll?.Invoke();
        }
    }
}
