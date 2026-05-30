using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip[] grassFootstepClips;
    [SerializeField] private float footstepInterval = 0.3f;
    [SerializeField] [Range(0f, 1f)] private float footstepVolume = 0.6f;
    [SerializeField] [Range(0.8f, 1.2f)] private float pitchVariation = 0.1f;

    [Header("Jump / Land Settings")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 0.8f;
    [SerializeField] [Range(0f, 1f)] private float landVolume = 0.8f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Grass Zone")]
    [SerializeField] private string grassZoneTag = "GrassZone";

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private AudioClip[] currentFootstepClips;
    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;
    private int grassZoneCount = 0; // tracks how many grass zones the cat is inside

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioSource.playOnAwake = false;
        currentFootstepClips = footstepClips;
    }

    void Update()
    {
        bool isGrounded = IsOnGround();
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        bool isMovingHorizontally = horizontalSpeed > 0.1f;

        if (isGrounded && isMovingHorizontally)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                PlayFootstep();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            PlayClip(jumpClip, jumpVolume);
            wasJumping = true;
        }

        if (!wasGrounded && isGrounded && wasJumping)
        {
            PlayClip(landClip, landVolume);
            wasJumping = false;
        }

        wasGrounded = isGrounded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(grassZoneTag))
        {
            grassZoneCount++;
            currentFootstepClips = grassFootstepClips;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(grassZoneTag))
        {
            grassZoneCount--;
            // only reset to default when fully outside all grass zones
            if (grassZoneCount <= 0)
            {
                grassZoneCount = 0;
                currentFootstepClips = footstepClips;
            }
        }
    }

    private void PlayFootstep()
    {
        if (currentFootstepClips == null || currentFootstepClips.Length == 0) return;

        AudioClip clip = currentFootstepClips[Random.Range(0, currentFootstepClips.Length)];
        audioSource.pitch = 1f + Random.Range(-pitchVariation, pitchVariation);
        audioSource.PlayOneShot(clip, footstepVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip == null) return;
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(clip, volume);
    }

    private bool IsOnGround()
    {
        if (groundCheck == null) return false;
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}