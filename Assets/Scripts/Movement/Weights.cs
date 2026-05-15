using UnityEngine;

public class Weights : MonoBehaviour
{
    public float weight = 1f;
}

/*using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Weights : MonoBehaviour
{
    public float weight = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight;
    }
}*/
/*
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Weights : MonoBehaviour
{
    public float weight = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = weight;
        rb.gravityScale = 2.5f;
        rb.linearDamping = 4f;
        rb.angularDamping = 0.05f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.sleepMode = RigidbodySleepMode2D.StartAwake;
    }
}
*/