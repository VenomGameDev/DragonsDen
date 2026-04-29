using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    
    public Animator animator;
    public bool isBlocking = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && FindObjectOfType<PlayerMovement>().horizontalMove == 0)
        {

            Block();
        }
        else
        {
            animator.SetBool("Block", false);
            isBlocking = false;
        }

        
    }

    void Block()
    {

        animator.SetBool("Block", true);
        isBlocking = true;

    }


}
