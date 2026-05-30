using UnityEngine;
using System.Collections;

public class MusicFadeOut : MonoBehaviour
{
    [SerializeField] private float delayBeforeFade = 3f;
    [SerializeField] private float fadeOutDuration = 3f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float startVolume = audioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeOutDuration);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }
}