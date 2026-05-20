using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptsGeraisDasSettings : MonoBehaviour
{
    [SerializeField] private GameObject objetoAlvo;
    private bool estaVisivel = true;
    [SerializeField] private string _sceneName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            estaVisivel = !estaVisivel;
            objetoAlvo.SetActive(estaVisivel);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
