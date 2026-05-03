using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private LineRenderer rope;
    [SerializeField] private Transform endTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, endTransform.position);
    }

    void Update()
    {
        rope.SetPosition(1, endTransform.position);
    }
}
