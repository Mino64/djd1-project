using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    private bool[] collected = new bool[5];
    public Vector3? LastCheckpointPosition { get; private set; } = null;

    [Header("Collectible Sprites")]
    [Tooltip("Sprites to show in the pause menu when each collectible is found (order matches slotIndex 0–4).")]
    [SerializeField] private Sprite[] collectedSprites = new Sprite[5];

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Collect(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= collected.Length) return;
        collected[slotIndex] = true;
        Debug.Log($"Slot {slotIndex} collected.");
    }

    public bool IsCollected(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= collected.Length) return false;
        return collected[slotIndex];
    }

    public bool[] GetAllCollected() => (bool[])collected.Clone();

    public Sprite GetSprite(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= collectedSprites.Length) return null;
        return collectedSprites[slotIndex];
    }

    public void SetCheckpoint(Vector3 position)
    {
        LastCheckpointPosition = position;
    }
}