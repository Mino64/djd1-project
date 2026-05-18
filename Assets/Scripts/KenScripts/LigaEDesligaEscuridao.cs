using UnityEngine;

public class LigaEDesligaEscuridao : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject objetoAlvo;
    [SerializeField] private Animator outroAnimator;

    private bool estaVisivel = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
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
