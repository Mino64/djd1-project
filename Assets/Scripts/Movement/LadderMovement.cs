using UnityEngine;

public class LadderMovement : MonoBehaviour
{

    [SerializeField] private float speed = 8f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator catAnimator;

    private float vertical;
    public float Vertical { get { return vertical; } }
    private bool isLadder;
    public bool IsLadder { get { return isLadder; } }
    private bool isClimbing;
    public bool IsClimbing { get { return isClimbing; } }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        if (isClimbing == true)
        {
            catAnimator.SetBool("IsClimbing", true);
            catAnimator.SetFloat("AbsVelocityY", Mathf.Abs(vertical));
        }
        else
        {
            catAnimator.SetBool("IsClimbing", false);
            catAnimator.SetFloat("AbsVelocityY", 0f);
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * speed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
