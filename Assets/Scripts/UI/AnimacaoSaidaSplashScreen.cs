using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AnimacaoSaidaSplashScreen : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float timer;

    [SerializeField]
    private string nomeanimacao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("blablabla");
        StartCoroutine("PlayAnimation");
    }

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(timer);
        animator.SetTrigger(nomeanimacao);
        Debug.Log("Sim eu sei");
    }
}
