/*using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip[] grassFootstepClips;
    [SerializeField] private float footstepInterval = 0.15f;
    [SerializeField] [Range(0f, 1f)] private float footstepVolume = 0.6f;
    [SerializeField] [Range(0f, 0.2f)] private float pitchVariation = 0.05f;

    [Header("Jump / Land Settings")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 0.8f;
    [SerializeField] [Range(0f, 1f)] private float landVolume = 0.8f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Sound Switch Trigger")]
    [SerializeField] private string switchZoneTag = "SwitchZone";

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private AudioClip[] currentFootstepClips;
    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioSource.playOnAwake = false;

        // start with grass sound
        currentFootstepClips = grassFootstepClips;
    }

    void Update()
    {
        bool isGrounded = IsOnGround();
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        bool isMovingHorizontally = horizontalSpeed > 0.1f;
        bool isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (!isAirborne && isMovingHorizontally)
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
        if (other.CompareTag(switchZoneTag))
        {
            // permanently switch to default footsteps
            currentFootstepClips = footstepClips;
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
}*/


/*using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip[] grassFootstepClips;
    [SerializeField] private float footstepInterval = 0.15f;
    [SerializeField] [Range(0f, 1f)] private float footstepVolume = 0.6f;
    [SerializeField] [Range(0f, 0.2f)] private float pitchVariation = 0.05f;

    [Header("Jump / Land Settings")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 0.8f;
    [SerializeField] [Range(0f, 1f)] private float landVolume = 0.8f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Sound Switch Trigger")]
    [SerializeField] private string switchToDefaultTag = "SwitchZone";
    [SerializeField] private string switchToGrassTag   = "GrassZone";

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private AudioClip[] currentFootstepClips;
    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioSource.playOnAwake = false;
        currentFootstepClips = grassFootstepClips;
    }

    void Update()
    {
        bool isGrounded = IsOnGround();
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        bool isMovingHorizontally = horizontalSpeed > 0.1f;
        bool isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (!isAirborne && isMovingHorizontally)
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
        if (other.CompareTag(switchToDefaultTag))
            currentFootstepClips = footstepClips;

        if (other.CompareTag(switchToGrassTag))
            currentFootstepClips = grassFootstepClips;
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
}*/


/*using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip[] grassFootstepClips;
    [SerializeField] private float footstepInterval = 0.15f;
    [SerializeField] [Range(0f, 1f)] private float footstepVolume = 0.6f;
    [SerializeField] [Range(0f, 0.2f)] private float pitchVariation = 0.05f;

    [Header("Jump / Land Settings")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 0.8f;
    [SerializeField] [Range(0f, 1f)] private float landVolume = 0.8f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Sound Switch Trigger")]
    [SerializeField] private string switchToDefaultTag = "SwitchZone";
    [SerializeField] private string switchToGrassTag   = "GrassZone";

    private AudioSource audioSource;
    private Rigidbody2D rb;

    private AudioClip[] currentFootstepClips;
    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioSource.playOnAwake = false;

        if (AudioState.Instance != null)
            currentFootstepClips = AudioState.Instance.usingGrassSound ? grassFootstepClips : footstepClips;
        else
            currentFootstepClips = grassFootstepClips;
    }

    void Update()
    {
        bool isGrounded = IsOnGround();
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        bool isMovingHorizontally = horizontalSpeed > 0.1f;
        bool isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (!isAirborne && isMovingHorizontally)
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
    }*/

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(switchToDefaultTag))
        {
            if (AudioState.Instance != null)
                AudioState.Instance.usingGrassSound = false;
            currentFootstepClips = footstepClips;
        }

        if (other.CompareTag(switchToGrassTag))
        {
            if (AudioState.Instance != null)
                AudioState.Instance.usingGrassSound = true;
            currentFootstepClips = grassFootstepClips;
        }
    }

    private void PlayFootstep()
    {
        if (currentFootstepClips == null || currentFootstepClips.Length == 0) return;

        AudioClip clip = currentFootstepClips[Random.Range(0, currentFootstepClips.Length)];
        audioSource.pitch = 1f + Random.Range(-pitchVariation, pitchVariation);
        audioSource.PlayOneShot(clip, footstepVolume);
    }*/

    /*private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Trigger entered: " + other.tag);

    if (other.CompareTag(switchToDefaultTag))
    {
        if (AudioState.Instance != null)
            AudioState.Instance.usingGrassSound = false;
        currentFootstepClips = footstepClips;
        Debug.Log("Switched to default footsteps. Clip count: " + footstepClips.Length);
    }

    if (other.CompareTag(switchToGrassTag))
    {
        if (AudioState.Instance != null)
            AudioState.Instance.usingGrassSound = true;
        currentFootstepClips = grassFootstepClips;
        Debug.Log("Switched to grass footsteps. Clip count: " + grassFootstepClips.Length);
    }
}

private void PlayFootstep()
{
    if (currentFootstepClips == null || currentFootstepClips.Length == 0)
    {
        Debug.LogWarning("No footstep clips!");
        return;
    }

    Debug.Log("Playing footstep from: " + currentFootstepClips[0].name);
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
}*/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioClip defaultFootstep;
    [SerializeField] private AudioClip grassFootstep;
    [SerializeField] private float footstepInterval = 0.3f;
    [SerializeField] [Range(0f, 1f)] private float footstepVolume = 1f;

    [Header("Jump / Land Settings")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] [Range(0f, 1f)] private float jumpVolume = 0.8f;
    [SerializeField] [Range(0f, 1f)] private float landVolume = 0.8f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Sound Switch Triggers")]
    [SerializeField] private string switchToGrassTag   = "GrassZone";
    [SerializeField] private string switchToDefaultTag = "SwitchZone";

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private AudioClip currentFootstep;
    private float footstepTimer = 0f;
    private bool wasGrounded = false;
    private bool wasJumping = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audioSource.playOnAwake = false;
        currentFootstep = defaultFootstep;
    }

    void Update()
    {
        bool isGrounded = IsOnGround();
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        bool isMovingHorizontally = horizontalSpeed > 0.1f;
        bool isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        if (!isAirborne && isMovingHorizontally)
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
        if (other.CompareTag(switchToGrassTag))
        {
            currentFootstep = grassFootstep;
            Debug.Log("Switched to grass sound");
        }

        if (other.CompareTag(switchToDefaultTag))
        {
            currentFootstep = defaultFootstep;
            Debug.Log("Switched to default sound");
        }
    }

    private void PlayFootstep()
    {
        if (currentFootstep == null) return;
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(currentFootstep, footstepVolume);
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
