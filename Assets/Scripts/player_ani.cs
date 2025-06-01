using UnityEngine;

public class player_ani : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool isMoving =
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);

        animator.SetBool("running", isMoving);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BOX"))
        {
            animator.SetBool("push", true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BOX"))
        {
            animator.SetBool("push", false);
        }
    }
}
