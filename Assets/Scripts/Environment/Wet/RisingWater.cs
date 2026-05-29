using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    [Header("Rising")]
    [SerializeField] private float riseSpeed = 1f;
    [SerializeField] private float maxY = 20f;


    [Header("Scene")]
    [SerializeField] private int levelSceneNum;
    [SerializeField] private float deathTime = 1f;

    private bool isRising = false;
    private GameObject player;

    public void StartRising()
    {
        isRising = true;
    }
    void Start()
    {
         player = FindAnyObjectByType<Player>().gameObject;
    }

    void Update()
    {
        if (!isRising) return;

        transform.position += Vector3.up * riseSpeed * Time.deltaTime;

        if (transform.position.y >= maxY)
            transform.position = new Vector3(
                transform.position.x, maxY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())

            StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel()
    {
        player.GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(deathTime);
        SceneManager.LoadScene(levelSceneNum);
    }
}