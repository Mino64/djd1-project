using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    [SerializeField] private int slotIndex = 0;

    void Start()
    {
        if (CollectibleManager.Instance != null && CollectibleManager.Instance.IsCollected(slotIndex))
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() == null) return;
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