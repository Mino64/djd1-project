using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 50f;
    [SerializeField] private float endYPosition = 2000f;
    [SerializeField] private int menuSceneNumber;
    [SerializeField] private float tempomenu = 2f;
    [SerializeField] private Animator animacao;

    private bool isEnding = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menuSceneNumber);
            return;
        }

        if (isEnding) return;

        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        if (transform.position.y >= endYPosition)
        {
            isEnding = true;
            animacao.Play("TransicaoSaida");
            StartCoroutine(VoltaProMenuComTempo());
        }
    }

    private IEnumerator VoltaProMenuComTempo()
    {
        yield return new WaitForSeconds(tempomenu);
        SceneManager.LoadScene(menuSceneNumber);
    }
}