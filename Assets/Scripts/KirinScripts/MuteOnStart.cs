using UnityEngine;

public class MuteOnStart : MonoBehaviour
{
    private float timer = 0f;
    private bool muted = true;

    void Start()
    {
        AudioListener.volume = 0f;
    }

    void Update()
    {
        if (!muted) return;

        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            AudioListener.volume = 1f;
            muted = false;
        }
    }
}