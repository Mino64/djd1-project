using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float changeSpeed = 1f;

    private void Start()
    {
        // Set slider to match current volume on start
        volumeSlider.value = AudioListener.volume;
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            volumeSlider.value = Mathf.Clamp01(volumeSlider.value + input * changeSpeed * Time.deltaTime);
            AudioListener.volume = volumeSlider.value;
        }
    }
}
