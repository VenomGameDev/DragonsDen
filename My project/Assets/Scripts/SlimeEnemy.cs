using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    
    [SerializeField] float slimeMoveSpeed = 2f;
    Rigidbody2D slimeRB2D;
    BoxCollider2D boxCollider2D;


    void Start()
    {
        slimeRB2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        SlimeMove();

    }


    void SlimeMove()
    {

        slimeRB2D.velocity = new Vector2 (slimeMoveSpeed, 0f);


    }

    void OnCollisionEnter2D(Collision2D other) 
        
    
    {
        slimeMoveSpeed = -slimeMoveSpeed;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f); 

    }
}
