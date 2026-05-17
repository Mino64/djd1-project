using System.Collections;
using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    [Header("Sound")]
    public AudioClip splashSound;
    [Range(0f, 1f)] public float volume = 1f;

    [Header("Animation")]
    public GameObject splashAnimationPrefab; // drag your splash prefab here
    public float splashOffsetY = 0f;         // adjust vertical spawn position if needed

    private AudioSource audioSource;

    void Awake()
    {
        // Create an AudioSource on this object to play the splash
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
        audioSource.clip = splashSound;
    }

    // This fires when the player enters the water trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySplash(other.transform.position);
        }
    }

    void PlaySplash(Vector3 contactPosition)
    {
        // Play sound
        audioSource.Play();

        // Spawn the splash animation at the point of contact
        if (splashAnimationPrefab != null)
        {
            Vector3 spawnPos = new Vector3(contactPosition.x, transform.position.y + splashOffsetY, contactPosition.z);
            GameObject splash = Instantiate(splashAnimationPrefab, spawnPos, Quaternion.identity);

            // Get how long the animation is and destroy the prefab after it finishes
            Animator anim = splash.GetComponent<Animator>();
            if (anim != null)
            {
                float clipLength = anim.GetCurrentAnimatorStateInfo(0).length;
                Destroy(splash, clipLength > 0 ? clipLength : 1f);
            }
            else
            {
                Destroy(splash, 1f); // fallback: destroy after 1 second
            }
        }
    }
}
