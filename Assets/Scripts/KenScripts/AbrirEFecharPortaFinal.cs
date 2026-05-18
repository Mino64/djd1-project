using UnityEngine;

public class AbrirEFecharPortaFinal : MonoBehaviour
{
    [SerializeField] private GameObject esteObjeto;

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TriggerPorta"))
        {
            esteObjeto.SetActive(false);
        }

    }
}