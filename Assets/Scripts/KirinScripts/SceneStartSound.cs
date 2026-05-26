/*using UnityEngine;

public class SceneStartSound : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float pitch = 1f;

    private float timer = 0f;
    private bool playing = false;

    void Start()
    {
        if (audioSource != null && sound != null)
        {
            audioSource.pitch = pitch;
            audioSource.volume = 1f;
            audioSource.PlayOneShot(sound);
            playing = true;
        }
    }

    void Update()
    {
        if (!playing) return;

        timer += Time.deltaTime;

        if (timer >= 1f) // starts fading at 1s, done at 2s
            audioSource.volume = Mathf.Lerp(1f, 0f, (timer - 0.3f) / 1.7f);

        if (timer >= 1.5f)
        {
            audioSource.Stop();
            playing = false;
        }
    }
}
*/

using UnityEngine;

public class SceneStartSound : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float pitch = 1f;

    private float timer = 0f;
    private bool playing = false;

    void Start()
    {
        if (audioSource != null && sound != null)
        {
            audioSource.pitch = pitch;
            audioSource.volume = 1f;
            audioSource.clip = sound;
            audioSource.Play();
            playing = true;
        }
    }

    void Update()
    {
        if (!playing) return;

        timer += Time.deltaTime;

        if (timer >= 0.3f)
            audioSource.volume = Mathf.Lerp(1f, 0f, (timer - 0.3f) / 1.2f);

        if (timer >= 1.5f)
        {
            audioSource.Stop();
            playing = false;
        }
    }
}