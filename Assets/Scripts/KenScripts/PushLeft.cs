using UnityEngine;

public class PushLeft : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Passadeira"))
    {
        transform.position += new Vector3(-1f, 0f, 0f);
    }
}

}
