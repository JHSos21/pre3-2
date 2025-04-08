using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float minZoom = 2f;
    public float maxZoom = 10f;
    public float panSpeed = 0.01f;
    private Vector3 lastMousePos;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        HandleZoom();
        HandlePan();
    }
    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scroll * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
    }
    void HandlePan()
    {
        if (Input.GetMouseButtonDown(2))
        {
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - lastMousePos;
            cam.transform.position -= delta * panSpeed;
            lastMousePos = Input.mousePosition;
        }
    }
}
