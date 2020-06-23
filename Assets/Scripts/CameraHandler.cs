using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float dragSpeed = 0.5f;
    public float zoomSpeed = 1;
    public float zoomFactor = 3.0f;
    public float minZoom = 4.5f;
    public float maxZoom = 8.0f;

    private Camera camera;

    private void Start()
    {
        this.camera = this.gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        DragController();
        ZoomController();
    }

    private void DragController()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            this.gameObject.transform.Translate(-new Vector3(Input.GetAxis("Mouse X") * dragSpeed, Input.GetAxis("Mouse Y") * dragSpeed, 0));
        }
    }

    private void ZoomController()
    {
        float targetZoom = Mathf.Clamp(this.camera.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomFactor, this.minZoom, this.maxZoom);

        this.camera.orthographicSize = Mathf.Lerp(this.camera.orthographicSize, targetZoom, Time.deltaTime * this.zoomSpeed);
    }
}
