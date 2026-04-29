using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    public float horizontalMove = 0f;
    public bool jump = false;


    void Update()
    {

        if (FindObjectOfType<PlayerBlock>().isBlocking == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        if (Input.GetButtonDown("Jump") && FindObjectOfType<PlayerBlock>().isBlocking == false)
        {
            jump = true;
            animator.SetTrigger("Jump");
            
        }
    }



    public void OnLanding()
    {

        animator.SetBool("isJumping", false);

    }


    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
