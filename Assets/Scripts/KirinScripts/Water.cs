using System.Collections;
using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private AudioClip splashSound;
    [Range(0f, 1f)][SerializeField]
    private float volume = 1f;

    [Header("Animation")]
    [SerializeField]
    private GameObject splashAnimationPrefab;
    [SerializeField]
    private float splashOffsetY = 0f;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
        audioSource.clip = splashSound;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            PlaySplash(other.transform.position);
        }
    }

    void PlaySplash(Vector3 contactPosition)
    {
        audioSource.Play();

        if (splashAnimationPrefab != null)
        {
            Vector3 spawnPos = new Vector3(contactPosition.x, transform.position.y + splashOffsetY, contactPosition.z);
            GameObject splash = Instantiate(splashAnimationPrefab, spawnPos, Quaternion.identity);

            Animator anim = splash.GetComponent<Animator>();
            if (anim != null)
            {
                StartCoroutine(DestroyAfterAnimation(splash, anim));
            }
            else
            {
                Destroy(splash, 1f);
            }
        }
    }

    IEnumerator DestroyAfterAnimation(GameObject splash, Animator anim)
    {
    yield return new WaitForSeconds(0.7f); // wait a bit longer
    float clipLength = anim.GetCurrentAnimatorStateInfo(0).length;
    Destroy(splash, clipLength > 0 ? clipLength : 1f);
    }

}
