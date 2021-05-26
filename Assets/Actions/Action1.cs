using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action1 : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public KeyCode left, right, jump, throws;

    public Rigidbody2D theRigidBody;

    bool isGrounded;


    public Transform groundCheck;

    private Animator anim;

    public float groundCheckRadius;
    public LayerMask ground;

    public GameObject snowBall;
    public Transform throwPoint;

    // Start is called before the first frame update
    void Start()
    {

        theRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

        if (Input.GetKey(left))
        {
            theRigidBody.velocity = new Vector2(-speed, theRigidBody.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRigidBody.velocity = new Vector2(speed, theRigidBody.velocity.y);
        }
        else
        {
            theRigidBody.velocity = new Vector2(0, theRigidBody.velocity.y);
        }

        if (Input.GetKeyDown(throws))
        {

            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");

        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRigidBody.velocity = new Vector2(theRigidBody.velocity.x, jumpForce);
        }

        if (theRigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRigidBody.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }
}
