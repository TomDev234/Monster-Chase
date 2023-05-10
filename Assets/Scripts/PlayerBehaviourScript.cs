using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f; // make Variable appear in the Component Editor
    [SerializeField] float jumpForce = 10f;
    float movementInput;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    const string WALK_PARAMETER = "Walk";
    const string GROUND_TAG = "Ground";
    const string MONSTER_TAG = "Monster";
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        AnimatePlayer();
        JumpPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(MONSTER_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(MONSTER_TAG))
        {
            Destroy(gameObject);
        }
    }

    void MovePlayer()
    {
        movementInput = Input.GetAxisRaw("Horizontal"); // Raw means no smoothing Filter
        transform.position += new Vector3(movementInput, 0f, 0f) * moveSpeed * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementInput > 0)
        {
            animator.SetBool(WALK_PARAMETER, true);
            spriteRenderer.flipX = false;
        }
        else if (movementInput < 0)
        {
            animator.SetBool(WALK_PARAMETER, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(WALK_PARAMETER, false);
        }
    }

    void JumpPlayer()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
         }
    }
}