using UnityEngine;

public class AbrirEFecharPortaFinal : MonoBehaviour
{
    [SerializeField] GameObject esteObjeto;

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TriggerPorta"))
        {
            esteObjeto.SetActive(false);
        }
        
    }
}