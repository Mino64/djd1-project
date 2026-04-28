using Unity.Collections;
using UnityEngine;

public class TriggerLigarEDesligar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject objetoAlvo;
    [SerializeField] Animator outroAnimator;

    bool estaVisivel = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            if (estaVisivel == false)
            {
                outroAnimator.Play("FadeOut");
            }
            else
            {
                outroAnimator.Play("FadeIn");
            }

            Invoke("MudarEstado", 1f); // tempo da animação
        }
    }

    void MudarEstado()
    {
        estaVisivel = !estaVisivel;
        //objetoAlvo.SetActive(estaVisivel);
    }

}
