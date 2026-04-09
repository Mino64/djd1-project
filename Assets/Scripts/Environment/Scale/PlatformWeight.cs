using UnityEngine;

public class PlatformWeight : MonoBehaviour
{
    [SerializeField]
    private Scale scale;
    [SerializeField]
    private string side;

    [SerializeField]
    private LayerMask boxLayer;


    private int count = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Box")) count++;
        scale.SetWeight(side, count);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Box")) count--;
        scale.SetWeight(side, count);
    }

}
