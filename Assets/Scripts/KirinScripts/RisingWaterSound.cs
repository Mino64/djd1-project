using UnityEngine;

public class RisingWaterSound : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float pitch = 1f;
    [SerializeField] private float volume = 1f;
    [SerializeField] private float fadeInDuration = 2f;
    [SerializeField] private float fadeOutDuration = 0.5f;

    private float lastY;
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeTimer = 0f;

    void Start()
    {
        audioSource.clip = sound;
        audioSource.pitch = pitch;
        audioSource.volume = 0f;
        audioSource.loop = true;
        lastY = transform.position.y;
    }

    void Update()
    {
        bool isRising = transform.position.y > lastY;

        if (isRising)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                isFadingIn = true;
                isFadingOut = false;
                fadeTimer = 0f;
            }

            if (isFadingOut)
            {
                isFadingOut = false;
                isFadingIn = true;
                fadeTimer = Mathf.InverseLerp(volume, 0f, audioSource.volume) * fadeInDuration;
            }
        }
        else if (audioSource.isPlaying && !isFadingOut)
        {
            isFadingOut = true;
            isFadingIn = false;
            fadeTimer = 0f;
        }

        if (isFadingIn)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, volume, fadeTimer / fadeInDuration);

            if (fadeTimer >= fadeInDuration)
            {
                audioSource.volume = volume;
                isFadingIn = false;
            }
        }

        if (isFadingOut)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(volume, 0f, fadeTimer / fadeOutDuration);

            if (fadeTimer >= fadeOutDuration)
            {
                audioSource.Stop();
                audioSource.volume = 0f;
                isFadingOut = false;
            }
        }

        lastY = transform.position.y;
    }
}