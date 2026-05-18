using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 0.5f;          // how fast the cloud moves
    [SerializeField] private float resetX = -15f;         // where the cloud resets (left side, off screen)
    [SerializeField] private float startX = 15f;          // where the cloud resets to (right side, off screen)

    void Update()
    {
        // Move the cloud to the left every frame
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // If the cloud has gone off the left side of the screen, send it back to the right
        if (transform.position.x < resetX)
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
}
/*using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 0.5f;
    public float resetX = -15f;

    private float startX; // no longer a public value you set manually

    void Start()
    {
        // Remember where THIS cloud started
        startX = transform.position.x;
    }

    /*void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < resetX)
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
    void Update()
{
    Debug.Log(gameObject.name + " position: " + transform.position.x);
    transform.Translate(Vector3.left * speed * Time.deltaTime);

    if (transform.position.x < resetX)
    {
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
    }
}
}*/