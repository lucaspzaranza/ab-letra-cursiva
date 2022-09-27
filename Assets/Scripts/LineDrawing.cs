using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class LineDrawing : MonoBehaviour
{
    public static event Action OnMeshDraw;

    public Camera mainCamera;
    public GameObject brush;
    public Material[] mats;
    public Rigidbody _rigidbody;
    public bool isErasing;

    private GameObject brushInstance;
    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        LetterScript.BeginErasing += SetIsErasingToTrue;
        LetterScript.OnErasedAll += DestroyAllMeshColliders;
    }

    private void OnDestroy()
    {
        LetterScript.BeginErasing -= SetIsErasingToTrue;
        LetterScript.OnErasedAll -= DestroyAllMeshColliders;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !UIWithIgnores() && !isErasing)
            Draw();

        if(brushInstance && Input.GetKeyUp(KeyCode.Mouse0) && !isErasing) // When releasing
        {
            MeshCollider collider = gameObject.AddComponent<MeshCollider>();

            if(currentLineRenderer != null)
            {
                Mesh mesh = new Mesh();
                currentLineRenderer.BakeMesh(mesh, true);
                collider.sharedMesh = mesh;
                OnMeshDraw?.Invoke();
                //HandleOnMeshDraw();
                //currentLineRenderer = null;
            }
        }

        /*else if (isErasing)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)) // Press
            {
                isErasing = false;
                eraser.SetActive(false);
                Debug.Log("Go back");                                 
            }
        }*/
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

    private void SetIsErasingToTrue() => isErasing = true;

    private void DestroyAllMeshColliders()
    {
        var colliders = GetComponents<MeshCollider>();

        if(colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                Destroy(colliders[i]);
            }
        }

        Invoke(nameof(SetIsErasingToFalse), 0.1f);
    }

    private void SetIsErasingToFalse()
    {
        isErasing = false;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private bool UIWithIgnores()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for(int i = 0; i < raycastResultList.Count; i++)
        {
            if(raycastResultList[i].gameObject.GetComponent<MouseUIClickThrough>() != null)
            {
                raycastResultList.RemoveAt(i);
                i--;
            }
        }
        return raycastResultList.Count > 0;
    }

    void Draw()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) // On Press
        {
            CreateBrush();
        }
        if(Input.GetKey(KeyCode.Mouse0)) // While holding
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos)
            {
                AddPoint(mousePos);
                lastPos = mousePos;
            }
        }
    }

    void CreateBrush () // Draw the brush when the player clicks
    {
        if (brush == null)
            return;

        brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddPoint(Vector2 pointPos)
    {
        if(currentLineRenderer != null)
        {
            currentLineRenderer.positionCount++;
            int positionIndex = currentLineRenderer.positionCount -1;
            currentLineRenderer.SetPosition(positionIndex, pointPos);
        }
    }

    public void ColorRed()
    {
        brush.GetComponent<Renderer>().material = mats[0];
    }

    public void ColorYellow()
    {
        brush.GetComponent<Renderer>().material = mats[1]; 
    }

    public void ColorGreen()
    {
        brush.GetComponent<Renderer>().material = mats[2]; 
    }

    public void ColorBlue()
    {
        brush.GetComponent<Renderer>().material = mats[3]; 
    }

    public void ColorPurple()
    {
        brush.GetComponent<Renderer>().material = mats[4]; 
    }

    public void ColorPink()
    {
        brush.GetComponent<Renderer>().material = mats[5]; 
    }

    public void EraseAll()
    {
        GameObject[] objects;
        objects = GameObject.FindGameObjectsWithTag("Player");
        if(objects.Length == 0) Debug.Log("No objects found!");
        else
        {
            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }
        }
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[currentLineRenderer.positionCount];
        currentLineRenderer.GetPositions(positions);
        return positions;
    }

    public float GetWidth()
    {
        return currentLineRenderer.startWidth;
    }
}
