using System.Collections;
using UnityEngine;

public class StopOnTrigger : MonoBehaviour
{
    public float stopDuration = 5f;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Cat"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                hasTriggered = true;
                StartCoroutine(FreezePlayer(player));
            }
        }
    }

    private IEnumerator FreezePlayer(Player player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Animator animator = player.GetComponent<Animator>();

        if (rb != null) rb.linearVelocity = Vector2.zero;

        if (animator != null)
        {
            animator.SetFloat("AbsVelocityX", 0f);
            animator.SetBool("IsGrounded", true);
        }

        player.enabled = false;

        yield return new WaitForSeconds(stopDuration);

        player.enabled = true;
    }
}