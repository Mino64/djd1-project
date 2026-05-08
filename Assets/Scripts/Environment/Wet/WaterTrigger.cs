using System;
using UnityEngine;

public class WaterActivator : MonoBehaviour
{
    [SerializeField] private RisingWater risingWater;
    [SerializeField] GameObject objetoAlvo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
            risingWater.StartRising();
            objetoAlvo.SetActive(true);
    }
}