using System.Drawing;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] points;

    private Transform currentPoint;

    public void SetCurrentPoint(Transform point, Collider2D collision)
    {
        if (!collision.CompareTag("Cat")) return;

        currentPoint = point;
        Debug.Log("Novo spawn: " + currentPoint.position);
    }

    public void Respawn()
    {
        if (currentPoint == null)
        {
            Debug.LogWarning("Nenhum spawnpoint definido!");
            return;
        }

        player.SetActive(false);
        player.transform.position = currentPoint.position;
        player.SetActive(true);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.SetActive(false);
        }

        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Respawn();
        }
    }
}
