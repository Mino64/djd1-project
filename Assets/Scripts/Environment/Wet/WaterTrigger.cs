using UnityEngine;

public class WaterActivator : MonoBehaviour
{
    [SerializeField] private RisingWater risingWater;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
            risingWater.StartRising();
    }
}