/*using UnityEngine;

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

using UnityEngine;

public class BoxLand : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private AudioClip landSound;

    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Header("Settings")]
    [SerializeField]
    private float minImpactVelocity = 2f;
    [SerializeField]
    private LayerMask groundLayers;
    [SerializeField]
    private float soundCooldown = 1f; // 500 milliseconds

    private AudioSource audioSource;
    private float lastSoundTime = 0f; // ensures sound can play immediately on first hit

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

        // Only trigger if cooldown has passed
        if (Time.time - lastSoundTime < soundCooldown) return;

        // Play sound
        audioSource.PlayOneShot(landSound);
        lastSoundTime = Time.time;
        Debug.Log("Sound played");

        // Trigger animation
        animator.SetTrigger("Land");
    }
}