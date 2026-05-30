using UnityEngine;

public class AudioState : MonoBehaviour
{
    public static AudioState Instance;
    public bool usingGrassSound = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}