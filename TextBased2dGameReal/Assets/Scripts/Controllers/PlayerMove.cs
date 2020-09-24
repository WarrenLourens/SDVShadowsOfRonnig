using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private bool Attack;
    private Rigidbody2D PlayerRigidBody;
    private bool facingRight;
    private Animator myAnimator;
    [SerializeField]
    private float MoveSpeed;
   
    void Start()
    {
        facingRight = true;
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
       
        
    }
    private void Update()
    {// If a player presses the escape key on their keyboard they will go back to the title screen.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
        HandleInput();
    }
    // Update is called once per frame
    void FixedUpdate()
    {// The movement code is placed in FixedUpdate as we are dealing with physics 
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
        ResetValues();
    }
    private void HandleMovement(float horizontal)
    {
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
        {
            PlayerRigidBody.velocity = new Vector2(horizontal*MoveSpeed, PlayerRigidBody.velocity.y);
        }
    
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void HandleAttacks() 
    {
        if (Attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) 
        {
            myAnimator.SetTrigger("Attack");
            PlayerRigidBody.velocity = Vector2.zero;
        }
    }
    private void HandleInput() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Attack = true;
        }
    }

    private void Flip(float movement) 
    {
        //This ensures that when the character turns  from left to right that the sprite faces the correct way.
        if (movement > 0 && !facingRight || movement < 0 && facingRight) 
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ResetValues() 
    {
        Attack = false;
    }
}
