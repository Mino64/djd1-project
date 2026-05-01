using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private SpawnPoint parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        parent.SetCurrentPoint(transform, collision);
    }

}
