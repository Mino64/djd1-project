using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip defaultFootstep;
    [SerializeField] [Range(0f, 1f)] private float defaultFootstepVolume = 1f;
    [SerializeField] private AudioClip grassFootstep;
    [SerializeField] [Range(0f, 1f)] private float grassFootstepVolume = 1f;
    [SerializeField] private float footstepInterval = 0.3f;
    [SerializeField] private LadderMovement ladderMovement;

    [Header("Jump / Land Settings")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 1f;
    [SerializeField] [Range(0f, 1f)] private float landVolume = 1f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Sound Switch Triggers")]
    [SerializeField] private string switchToGrassTag   = "GrassZone";
    [SerializeField] private string switchToDefaultTag = "SwitchZone";

    [Header("Ladder Settings")]
    [SerializeField] private AudioClip ladderClip;
    [SerializeField] [Range(0f, 1f)] private float ladderVolume = 1f;
    [SerializeField] private float ladderInterval = 0.3f;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private AudioClip currentFootstep;
    private float currentFootstepVolume;
    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;
    private float ladderTimer = 0f;

    //private bool onLadder = false;
    // private bool ladderBoolTest;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioSource.playOnAwake = false;
        currentFootstep = defaultFootstep;
        currentFootstepVolume = defaultFootstepVolume;
    }

    void Update()
    {
        bool isGrounded = IsOnGround();
        bool onLadderAndMoving = ladderMovement != null && ladderMovement.IsClimbing && Mathf.Abs(ladderMovement.Vertical) > 0.1f;
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        float verticalSpeed = Mathf.Abs(rb.linearVelocity.y);
        bool isMoving = horizontalSpeed > 0.1f && verticalSpeed < 0.1f;
        bool isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (!isAirborne && isMoving)
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

        if (onLadderAndMoving)
        {
            ladderTimer -= Time.deltaTime;
            if (ladderTimer <= 0f)
            {
                PlayClip(ladderClip, ladderVolume);
                ladderTimer = ladderInterval;
            }
        }
        else
        {
            ladderTimer = 0f;
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
        if (other.CompareTag(switchToGrassTag))
        {
            currentFootstep = grassFootstep;
            currentFootstepVolume = grassFootstepVolume;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(switchToGrassTag))
        {
            currentFootstep = defaultFootstep;
            currentFootstepVolume = defaultFootstepVolume; 
        }
    }
        /*
        if (other.CompareTag(switchToDefaultTag))
        {
            currentFootstep = defaultFootstep;
            currentFootstepVolume = defaultFootstepVolume;
        }

        //if (other.CompareTag("Ladder"))
            //onLadder = true;
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
            onLadder = false;
    }
*/
    private void PlayFootstep()
    {
        if (currentFootstep == null) return;
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(currentFootstep, currentFootstepVolume);
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