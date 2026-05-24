using UnityEngine;

public class PushLeft : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.GetComponent<Player>())
    {
        collision.transform.position += new Vector3(-1f, 0f, 0f);
    }
}

}
