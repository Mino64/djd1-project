using UnityEngine;

public class SeesawTrigger2D : MonoBehaviour
{
    public SimpleSeesaw2D seesaw;
    public bool isLeft;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box") || other.CompareTag("Cat"))
        {
            if (isLeft)
                seesaw.AddLeft(other.gameObject);
            else
                seesaw.AddRight(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box")|| other.CompareTag("Cat"))
        {
            if (isLeft)
                seesaw.RemoveLeft(other.gameObject);
            else
                seesaw.RemoveRight(other.gameObject);
        }
    }
}