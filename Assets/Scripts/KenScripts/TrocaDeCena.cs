using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaDeCena : MonoBehaviour
{
    [SerializeField] Animator outroAnimator;
    [SerializeField] GameObject agua;
    [SerializeField] private int _sceneNumber;


    void PassaCena(){

        agua.SetActive(false);
        outroAnimator.Play("AguaSubindoMenus");
        Invoke("PassaProxima", 2f); // tempo da animação
    }

    void PassaProxima()
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            PassaCena();
        }
    }
}
