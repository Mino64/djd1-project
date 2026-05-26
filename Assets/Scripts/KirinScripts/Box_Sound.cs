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
}*/

using UnityEngine;

public class BoxSound : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip pushSound;
    [SerializeField] [Range(0.1f, 3f)] private float playbackSpeed = 1f;
    [SerializeField] Animator animacao;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.clip = pushSound;
        audioSource.pitch = playbackSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            animacao.Play("AnimacaoCaixaPequena1Cair", 0, 0f); 
        }

        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.transform.position.y > transform.position.y)
                return;

            audioSource.pitch = playbackSpeed;
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
