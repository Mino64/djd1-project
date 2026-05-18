using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    [SerializeField] Animator outroAnimator;
    [SerializeField]
    private string _sceneName;


    void PassaCena(){

        outroAnimator.Play("AguaSubindoMenus");
        Invoke("PassaProxima", 2f); // tempo da animação
    }

    void PassaProxima()
    {
        SceneManager.LoadScene(_sceneName);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PassaCena();
        }
    }
}
