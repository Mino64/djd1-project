using System;
using UnityEngine;

public class MudancaPosicaoCamara : MonoBehaviour
{
    [SerializeField] private Vector3 NovaPos;
    [SerializeField] private GameObject camara;

    void OnTriggerEnter2D(Collider2D collision)
    {
        camara.transform.position = NovaPos;
    }
}
