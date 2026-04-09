using UnityEngine;

public class SeesawDetector2D : MonoBehaviour
{
    [SerializeField] private SmoothSeesaw2D seesaw;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Cat"))
        {
            seesaw.AddObject(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Cat"))
        {
            seesaw.RemoveObject(other.gameObject);
        }
    }
}