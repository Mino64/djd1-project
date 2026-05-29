using UnityEngine;

public class CameraZoomTrigger : MonoBehaviour
{
    [SerializeField] private float targetSize    = 10f;  // orthographic size to zoom to
    [SerializeField] private float zoomDuration  = 1f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
            if (cam != null)
                cam.ZoomTo(targetSize, zoomDuration);
        }
    }
}