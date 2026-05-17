using System.Drawing;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] points;

    private Transform currentPoint;
        private void Start()
    {
        // If the scene was reloaded via the pause menu, restore the last checkpoint position
        if (CollectibleManager.Instance != null && CollectibleManager.Instance.LastCheckpointPosition.HasValue)
        {
            player.transform.position = CollectibleManager.Instance.LastCheckpointPosition.Value;
        }
    }

    public void SetCurrentPoint(Transform point, Collider2D collision)
    {
        if (collision.GetComponent<Player>() == null) return;

        currentPoint = point;
         CollectibleManager.Instance?.SetCheckpoint(point.position);
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
        
      /*  if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.SetActive(false);
        }

        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Respawn();
        }*/
    }
}
