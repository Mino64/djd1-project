using UnityEngine;
using System.Collections;

public class WaterTrigger : MonoBehaviour
{
    [Header("Camera Shake")]
    [SerializeField] private float shakeDuration  = 0.4f;
    [SerializeField] private float shakeMagnitude = 0.15f;

    [Header("Water Sound")]
    [SerializeField] private AudioClip waterSound;
    [SerializeField] private float     peakVolume    = 1f;
    [SerializeField] private float     fadeInSeconds  = 0.3f;
    [SerializeField] private float     holdSeconds    = 1f;   // time at peak before fade out
    [SerializeField] private float     fadeOutSeconds = 0.8f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger entered by: {other.name}, tag: {other.tag}");

        if (hasTriggered) return;

        if (other.CompareTag("Cat"))
        {
            Player player = other.GetComponent<Player>();
            Debug.Log($"Player found: {player != null}");

            if (player != null)
            {
                hasTriggered = true;

                // camera shake
                CameraFollow cam = Camera.main.GetComponent<CameraFollow>();
                Debug.Log($"CameraFollow found: {cam != null}");
                if (cam != null)
                    cam.Shake(shakeDuration, shakeMagnitude);

                // water sound
                StartCoroutine(PlayWaterSound());
            }
        }
    }

    private IEnumerator PlayWaterSound()
    {
        if (waterSound == null)
        {
            Debug.LogWarning("WaterTrigger: no AudioClip assigned!");
            yield break;
        }

        // create a temporary audio source so it doesn't get cut off
        // if this GameObject is disabled later
        GameObject audioObj = new GameObject("WaterSoundTemp");
        AudioSource source  = audioObj.AddComponent<AudioSource>();
        source.clip         = waterSound;
        source.loop         = false;
        source.volume       = 0f;
        source.Play();

        // fade in
        float elapsed = 0f;
        while (elapsed < fadeInSeconds)
        {
            source.volume = Mathf.Lerp(0f, peakVolume, elapsed / fadeInSeconds);
            elapsed += Time.deltaTime;
            yield return null;
        }
        source.volume = peakVolume;

        // hold at peak
        yield return new WaitForSeconds(holdSeconds);

        // fade out
        elapsed = 0f;
        while (elapsed < fadeOutSeconds)
        {
            source.volume = Mathf.Lerp(peakVolume, 0f, elapsed / fadeOutSeconds);
            elapsed += Time.deltaTime;
            yield return null;
        }
        source.volume = 0f;
        source.Stop();

        Destroy(audioObj);
    }
}