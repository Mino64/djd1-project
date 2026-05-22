using UnityEngine;

public class StopOnTrigger : MonoBehaviour
{
    [SerializeField] private float shakeDuration  = 0.4f;
    [SerializeField] private float shakeMagnitude = 0.15f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger entered by: {other.name}, tag: {other.tag}");

        if (hasTriggered) return;

        if (other.CompareTag("Cat"))
        {
            Player player = other.GetComponent<Player>();
            Debug.Log($"Player component found: {player != null}");

            if (player != null)
            {
                hasTriggered = true;

                CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
                Debug.Log($"CameraFollow found: {cam != null}");

                if (cam != null)
                    cam.Shake(shakeDuration, shakeMagnitude);
            }
        }
    }
}