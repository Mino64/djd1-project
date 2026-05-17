using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    private bool[] collected = new bool[5];
    public Vector3? LastCheckpointPosition { get; private set; } = null;

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
    public void SetCheckpoint(Vector3 position)
    {
        LastCheckpointPosition = position;
    }
}