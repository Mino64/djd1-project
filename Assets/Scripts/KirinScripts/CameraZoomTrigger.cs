using UnityEngine;

public class CameraZoomTrigger : MonoBehaviour
{
    [SerializeField] private float targetSize   = 10f;
    [SerializeField] private float zoomDuration = 1f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Cat"))
        {
            CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
            if (cam != null)
            {
                hasTriggered = true;
                cam.ZoomTo(targetSize, zoomDuration);
            }
        }
    }
}