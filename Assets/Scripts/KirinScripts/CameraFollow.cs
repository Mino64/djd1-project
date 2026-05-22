/*using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float     speed = 150;
    [SerializeField] private Vector3   offset;
    [SerializeField] private BoxCollider2D boundingBox;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            Player player = FindFirstObjectByType<Player>();
            if (player != null)
            { 
                target = player.transform;
            }
            else
            {
                return;
            }
        }

        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        //transform.position = Vector3.MoveTowards(transform.position, currentPosition, speed * Time.fixedDeltaTime);
        Vector3 error = targetPosition - transform.position;
        Vector3 newPosition = transform.position + error * speed;
        
                if (boundingBox != null)
            newPosition = ClampToBounds(newPosition);
 
        transform.position = newPosition;
    }
     private Vector3 ClampToBounds(Vector3 position)
    {

        Bounds bounds = boundingBox.bounds;

        float halfHeight = cam.orthographicSize;
        float halfWidth  = cam.orthographicSize * cam.aspect;
        float clampedX = Mathf.Clamp(position.x, bounds.min.x + halfWidth,  bounds.max.x - halfWidth);
        float clampedY = Mathf.Clamp(position.y, bounds.min.y + halfHeight, bounds.max.y - halfHeight);
 
        return new Vector3(clampedX, clampedY, position.z);
    }
}*/
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 150;
    [SerializeField] private Vector3 offset;
    [SerializeField] private BoxCollider2D boundingBox;

    private Camera cam;
    private Vector3 shakeOffset = Vector3.zero;

    void Start()
    {
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            Player player = FindFirstObjectByType<Player>();
            if (player != null)
                target = player.transform;
            else
                return;
        }

        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        Vector3 error = targetPosition - transform.position - shakeOffset;
        Vector3 newPosition = transform.position + error * speed;

        if (boundingBox != null)
            newPosition = ClampToBounds(newPosition);

        transform.position = newPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float progress = elapsed / duration;
            float dampedMagnitude = magnitude * (1f - progress); // fade out over time

            shakeOffset = new Vector3(
                Random.Range(-1f, 1f) * dampedMagnitude,
                Random.Range(-1f, 1f) * dampedMagnitude,
                0f
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        shakeOffset = Vector3.zero;
    }

    private Vector3 ClampToBounds(Vector3 position)
    {
        Bounds bounds = boundingBox.bounds;
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.orthographicSize * cam.aspect;
        float clampedX = Mathf.Clamp(position.x, bounds.min.x + halfWidth, bounds.max.x - halfWidth);
        float clampedY = Mathf.Clamp(position.y, bounds.min.y + halfHeight, bounds.max.y - halfHeight);
        return new Vector3(clampedX, clampedY, position.z);
    }
}
