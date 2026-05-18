using UnityEngine;

public class BoxLand : MonoBehaviour
{
    [Header("Sound")]
    public AudioClip landSound;

    [Header("Animation")]
    public Animator animator;

    [Header("Settings")]
    public float minImpactVelocity = 2f;
    public LayerMask groundLayers;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is on any of the selected layers
        if ((groundLayers.value & (1 << collision.gameObject.layer)) == 0) return;

        // Only trigger if falling fast enough
        float impactSpeed = Mathf.Abs(collision.relativeVelocity.y);
        if (impactSpeed < minImpactVelocity) return;

        // Play sound
        audioSource.PlayOneShot(landSound);
        Debug.Log("Sound played");

        // Trigger animation
        animator.SetTrigger("Land");
    }
}


/*using UnityEngine;

public class BoxLand : MonoBehaviour
{
    [Header("Sound")]
    public AudioClip landSound;

    [Header("Animation")]
    public Animator animator;

    [Header("Settings")]
    public float minImpactVelocity = 2f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger if hitting layer 6 (Ground)
        if (collision.gameObject.layer != 6) return;

        // Only trigger if falling fast enough
        float impactSpeed = Mathf.Abs(collision.relativeVelocity.y);
        if (impactSpeed < minImpactVelocity) return;

        // Play sound
        audioSource.PlayOneShot(landSound);

        // Trigger animation
        animator.SetTrigger("Land");
    }
}*/