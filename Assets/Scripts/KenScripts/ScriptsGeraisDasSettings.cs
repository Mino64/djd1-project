using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptsGeraisDasSettings : MonoBehaviour
{
    [SerializeField] private GameObject objetoAlvo;
    [SerializeField] private GameObject objetoScroll;
    private bool estaVisivel = true;
    private bool estaVisivel2 = true;
    [SerializeField] private int _sceneNum;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            estaVisivel = !estaVisivel;
            estaVisivel2 = !estaVisivel2;
            objetoAlvo.SetActive(estaVisivel);
            objetoScroll.SetActive(estaVisivel2);

        }

        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(_sceneNum);
        }
    }
}
