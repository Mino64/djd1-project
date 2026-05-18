using UnityEngine;

public class AnimacaoAguaSubindo : MonoBehaviour
{

    [SerializeField] private Animator outroAnimator;

    // Update is called once per frame
    private void Update()
    {
        Invoke("PassaAnimacao", 1f); // tempo da animação
    }

    private void PassaAnimacao()
    {
        outroAnimator.Play("AguaSubindoMenus");
    }
}
