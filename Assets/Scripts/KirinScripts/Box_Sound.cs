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
/*
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip soundStart;
    public AudioClip soundMiddle;
    public AudioClip soundEnd;

    [Header("Push Detection")]
    public float moveThreshold = 0.1f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        bool boxIsMoving = rb.linearVelocity.magnitude > moveThreshold;

        if (boxIsMoving && !isMoving)
        {
            isMoving = true;
            PlayStart();
        }
        else if (!boxIsMoving && isMoving)
        {
            isMoving = false;
            PlayEnd();
        }
    }

    void PlayStart()
    {
        audioSource.loop = false;
        audioSource.clip = soundStart;
        audioSource.Play();
        Invoke(nameof(PlayMiddle), soundStart.length);
    }

    void PlayMiddle()
    {
        if (!isMoving) return;
        audioSource.loop = true;
        audioSource.clip = soundMiddle;
        audioSource.Play();
    }

    void PlayEnd()
    {
        CancelInvoke(nameof(PlayMiddle));
        audioSource.loop = false;
        audioSource.clip = soundEnd;
        audioSource.Play();
    }
}*/
/*
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip soundStart;
    public AudioClip soundMiddle;
    public AudioClip soundEnd;

    [Header("Push Detection")]
    public float moveThreshold = 0.1f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        bool boxIsMoving = rb.linearVelocity.magnitude > moveThreshold;

        if (boxIsMoving && !isMoving)
        {
            isMoving = true;
            PlayStart();
        }
        else if (!boxIsMoving && isMoving)
        {
            isMoving = false;
            PlayEnd();
        }
    }

    void PlayStart()
    {
        audioSource.loop = false;
        audioSource.clip = soundStart;
        audioSource.Play();
        Invoke(nameof(PlayMiddle), soundStart.length);
    }

    void PlayMiddle()
    {
        if (!isMoving) return;
        audioSource.loop = true;
        audioSource.clip = soundMiddle;
        audioSource.Play();
    }

    void PlayEnd()
    {
        CancelInvoke(nameof(PlayMiddle));
        audioSource.Stop(); // stops the current sound immediately
        audioSource.loop = false;
        audioSource.clip = soundEnd;
        audioSource.Play();
    }
}*/
/*
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip soundStart;
    public AudioClip soundMiddle;

    [Header("Push Detection")]
    public float moveThreshold = 0.1f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        bool boxIsMoving = rb.linearVelocity.magnitude > moveThreshold;

        if (boxIsMoving && !isMoving)
        {
            isMoving = true;
            PlayStart();
        }
        else if (!boxIsMoving && isMoving)
        {
            isMoving = false;
            StopSound();
        }
    }

    void PlayStart()
    {
        audioSource.loop = false;
        audioSource.clip = soundStart;
        audioSource.Play();
        Invoke(nameof(PlayMiddle), soundStart.length);
    }

    void PlayMiddle()
    {
        if (!isMoving) return;
        audioSource.loop = true;
        audioSource.clip = soundMiddle;
        audioSource.Play();
    }

    void StopSound()
    {
        CancelInvoke(nameof(PlayMiddle));
        audioSource.Stop();
    }
}*/
/*
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip soundStart;
    public AudioClip soundMiddle;

    [Header("Push Detection")]
    public float moveThreshold = 0.1f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        bool boxIsMoving = rb.linearVelocity.magnitude > moveThreshold;

        Debug.Log("Box velocity: " + rb.linearVelocity.magnitude + " | isMoving: " + isMoving);

        if (boxIsMoving && !isMoving)
        {
            isMoving = true;
            PlayStart();
        }
        else if (!boxIsMoving && isMoving)
        {
            isMoving = false;
            Debug.Log("STOPPING SOUND NOW");
            StopSound();
        }
    }

    void PlayStart()
    {
        audioSource.loop = false;
        audioSource.clip = soundStart;
        audioSource.Play();
        Invoke(nameof(PlayMiddle), soundStart.length);
    }

    void PlayMiddle()
    {
        if (!isMoving) return;
        audioSource.loop = true;
        audioSource.clip = soundMiddle;
        audioSource.Play();
    }

    void StopSound()
    {
        CancelInvoke(nameof(PlayMiddle));
        audioSource.Stop();
        Debug.Log("AudioSource stopped. Is playing: " + audioSource.isPlaying);
    }
}*/
/*
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip pushSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.clip = pushSound;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            audioSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            audioSource.Stop();
        }
    }
}*/

using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip pushSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.clip = pushSound;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            // Ignore if cat is on top of the box
            if (collision.gameObject.transform.position.y > transform.position.y)
                return;

            audioSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            audioSource.Stop();
        }
    }
}
