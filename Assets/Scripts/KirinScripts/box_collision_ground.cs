using UnityEngine;

public class BoxLand : MonoBehaviour
{
    [Header("Sound")]
    public AudioClip landSound;

    [Header("Animation")]
    public Animator animator;

    [Header("Settings")]
    public float minImpactVelocity = 2f; // minimum fall speed to trigger sound and animation

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger if hitting the ground
        if (!collision.gameObject.CompareTag("Ground")) return;

        // Only trigger if falling fast enough
        float impactSpeed = Mathf.Abs(collision.relativeVelocity.y);
        if (impactSpeed < minImpactVelocity) return;

        // Play sound
        audioSource.PlayOneShot(landSound);

        // Trigger animation
        animator.SetTrigger("Land");
    }
}