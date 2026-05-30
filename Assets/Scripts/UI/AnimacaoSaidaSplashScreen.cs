using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimacaoSaidaSplashScreen : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float timer;

    [SerializeField] private float timerSaida;

    [SerializeField]
    private string nomeanimacao;

    [SerializeField]
    private int _sceneNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlayAnimation());
        StartCoroutine(TrocaCena());
    }

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(timer);
        animator.SetTrigger(nomeanimacao);
    }

    private IEnumerator TrocaCena()
    {
        yield return new WaitForSeconds(timerSaida);
        SceneManager.LoadScene(_sceneNumber);
    }
}
