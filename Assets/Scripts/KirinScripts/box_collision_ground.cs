using UnityEngine;

public class BoxLand : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private AudioClip landSound;
    [SerializeField]
    [Range(0f, 1f)] private float landVolume = 1f;

    [SerializeField]
    private AudioClip waterLandSound;
    [SerializeField]
    [Range(0f, 1f)] private float waterLandVolume = 1f;
    [SerializeField]
    [Range(0.1f, 3f)] private float waterLandPitch = 1f;

    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Header("Settings")]
    [SerializeField]
    private float minImpactVelocity = 2f;
    [SerializeField]
    private LayerMask groundLayers;
    [SerializeField]
    private float soundCooldown = 1f;

    private AudioSource audioSource;
    private float lastSoundTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if ((groundLayers.value & (1 << collision.gameObject.layer)) == 0) return;

        float impactSpeed = Mathf.Abs(collision.relativeVelocity.y);
        if (impactSpeed < minImpactVelocity) return;

        if (Time.time - lastSoundTime < soundCooldown) return;

        audioSource.PlayOneShot(landSound, landVolume);
        lastSoundTime = Time.time;

        animator.SetTrigger("Land");
    }*/

    void OnCollisionEnter2D(Collision2D collision)
{
    if ((groundLayers.value & (1 << collision.gameObject.layer)) == 0) return;

    float impactSpeed = Mathf.Abs(collision.relativeVelocity.y);
    if (impactSpeed < minImpactVelocity) return;

    if (Time.time - lastSoundTime < soundCooldown) return;

    if (collision.gameObject.CompareTag("Water"))
    {
        audioSource.pitch = waterLandPitch;
        audioSource.PlayOneShot(waterLandSound, waterLandVolume);
    }
    else
    {
        audioSource.pitch = 1f;
        audioSource.PlayOneShot(landSound, landVolume);
    }

    lastSoundTime = Time.time;
    animator.SetTrigger("Land");
}
}

