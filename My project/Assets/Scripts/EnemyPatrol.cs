using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private GameObject healthBar;

    [Header("Movement parameters")]
    [SerializeField] public float speed;
    private Vector3 initScale;
    public bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField] private Animator anim;

    private void Awake() 
        {

            initScale = enemy.localScale;

        }
    


    private void Update()
    {
        
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x){
                MoveInDirection(-1);
            healthBar.transform.localScale = new Vector3(Mathf.Abs(healthBar.transform.localScale.x) * -1, 0.0025f, 1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x){
                MoveInDirection(1);
            healthBar.transform.localScale = new Vector3(Mathf.Abs(healthBar.transform.localScale.x) * 1, 0.0025f, 1);
            }
                
            else
            {
                DirectionChange();
            }
        
        }
    }

private void DirectionChange()
{
    anim.SetBool("move", false);
    

    idleTimer += Time.deltaTime;

    if (idleTimer > idleDuration)
        movingLeft = !movingLeft;
        
}


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("move", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
        initScale.y, initScale.z);
        //MOve in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction *speed,
        enemy.position.y, enemy.position.z);
        

    }









}
