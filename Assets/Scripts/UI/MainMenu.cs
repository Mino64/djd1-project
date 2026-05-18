using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    // Coisas do Ken
    [SerializeField] Animator outroAnimator;
    [SerializeField] GameObject objetoAlvo1;
    [SerializeField] GameObject objetoAlvo2;
    [SerializeField] GameObject objetoAlvo3;
    [SerializeField] GameObject objetoAlvo4;


    public void PlayGame()
    {
        //Coisas do Ken
        objetoAlvo1.SetActive(false);
        objetoAlvo2.SetActive(false);
        objetoAlvo3.SetActive(false);
        objetoAlvo4.SetActive(false);
        outroAnimator.Play("AguaSubindoMenus");
        Invoke("ComecaJogo", 2f); // tempo da animação
    }

    void ComecaJogo()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
