using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip[] footstepClips;
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

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        // Make sure the AudioSource doesn't play on awake
        audioSource.playOnAwake = false;
    }

    
    void Update()
    {
        //bool isGrounded = wasGrounded;
        bool isGrounded = IsOnGround();
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        bool isMovingHorizontally = horizontalSpeed > 0.1f;

        // --- Footsteps ---
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
            // Reset timer so next step plays immediately when movement resumes
            footstepTimer = 0f;
        }

        // --- Jump sound ---
        // Detects the moment the player leaves the ground going upward
        /*if (wasGrounded && !isGrounded && rb.linearVelocity.y > 0f)
        {
            PlayClip(jumpClip, jumpVolume);
            wasJumping = true;
        }*/
        // --- Jump sound ---
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            PlayClip(jumpClip, jumpVolume);
            wasJumping = true;
        }
        // --- Jump sound ---
        /*
        if (isGrounded && Input.GetButtonDown("Jump"))
        {       
            PlayClip(jumpClip, jumpVolume);
            wasJumping = true;
        }*/

        // --- Land sound ---
        // Detects the moment the player touches the ground after being airborne
        if (!wasGrounded && isGrounded && wasJumping)
        {
            PlayClip(landClip, landVolume);
            wasJumping = false;
        }

        wasGrounded = isGrounded;
    }



    private void PlayFootstep()
    {
        if (footstepClips == null || footstepClips.Length == 0) return;

        AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
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
