using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BoxAudioOnWater : MonoBehaviour
{
    [SerializeField] private AudioClip waterSplashClip;
    [SerializeField] [Range(0f, 1f)] private float splashVolume = 0.8f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            audioSource.PlayOneShot(waterSplashClip, splashVolume);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            audioSource.PlayOneShot(waterSplashClip, splashVolume);
        }
    }
}
