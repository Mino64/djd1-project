using UnityEngine;

public class AnimacaoAguaSubindo : MonoBehaviour
{
    
    [SerializeField] Animator outroAnimator;

    // Update is called once per frame
    void Update()
    {
        Invoke("PassaAnimacao", 1f); // tempo da animação
    }

    void PassaAnimacao()
    {
        outroAnimator.Play("AguaSubindoMenus");
    }
}
