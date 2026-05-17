using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    [SerializeField] private int slotIndex = 0;

    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private bool playerIsNear = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
        playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
            playerIsNear = false;
    }

    private void Update()
    {
        if (playerIsNear && Input.GetKeyDown(interactKey))
            Collect();
    }

    private void Collect()
    {
        if (CollectibleManager.Instance == null)
        {
            Debug.LogWarning("oopsies no manager exists");
            return;
        }

        CollectibleManager.Instance.Collect(slotIndex);
        Destroy(gameObject);
    }
}