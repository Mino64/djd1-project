using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private float changeSpeed = 1f;

    private Slider volumeSlider;

    private void OnEnable()
    {
        volumeSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (volumeSlider == null) return;

        float input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            volumeSlider.value = Mathf.Clamp01(volumeSlider.value + input * changeSpeed * Time.deltaTime);
            AudioListener.volume = volumeSlider.value * volumeSlider.value;
        }
    }
}