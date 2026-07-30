using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Movement Setting")]
    public float moveSpeed = 10f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 15f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    void HandleMovement()
    {
        float x = 0f;
        float y = 0f;
        if(Keyboard.current != null)
        {
            if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1f;
            if(Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1f;

            if(Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) y = 1f;
            if(Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) y = -1f;

            Vector3 move = new Vector3(x,y,0)*moveSpeed*Time.deltaTime;
            transform.Translate(move, Space.World);
        }
    
    }

    void HandleZoom()
    {
        if(Mouse.current != null)
        {
            float scrollValue = Mouse.current.scroll.ReadValue().y;

            if(scrollValue != 0)
            {
                cam.orthographicSize -= (scrollValue * 0.01f) * zoomSpeed;
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
            }
        }
    }
}
