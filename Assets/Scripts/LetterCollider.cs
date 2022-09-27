using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCollider : MonoBehaviour
{
    public static event Action OnLetterColliderChecked;

    public bool Checked = false;
    public Rigidbody _rigidbody;
    public float _timeToSetFalse;

    private void Start()
    {
        LineDrawing.OnMeshDraw += HandleOnMeshDraw;

        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke(nameof(SetCheckedToFalse), _timeToSetFalse);
    }

    private void SetCheckedToFalse() => Checked = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DrawTraces") && !Checked)
        {
            Checked = true;
            OnLetterColliderChecked?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void HandleOnMeshDraw()
    {
        if (_rigidbody == null)
            return;

        // This is a key to force the rigidbody to check the collision with the letter trace
        Invoke(nameof(ToggleIsKinematic), 0.1f);
        Invoke(nameof(ToggleIsKinematic), 0.2f);

        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }

    private void ToggleIsKinematic()
    {
        _rigidbody.isKinematic = !_rigidbody.isKinematic;
    }

    
}
