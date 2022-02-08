using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    
public Transform target;

public float speed = 200f;
public float nextWaypointDistance = 3f;
public bool lookingRight = false;

public Transform enemyGFX;

Path path;
int currentWayPoint = 0;
bool reachedEndOfPath = false;

Seeker seeker;
Rigidbody2D rb;

void Start()
{
    seeker = GetComponent<Seeker>();
    rb = GetComponent<Rigidbody2D>();

     
    


}

void Update()
{

    InvokeRepeating("UpdatePath", 0f, .5f); 

}

void UpdatePath()
{
    if (seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);


}

void OnPathComplete(Path p)
{
    if (!p.error)
    {
        path = p;
        currentWayPoint = 0;


    }
}


void FixedUpdate() 

{
    if (path == null)
        return;
    
    if (currentWayPoint >= path.vectorPath.Count)
    {
        reachedEndOfPath =true;
        return;
    }
    else
    {
        reachedEndOfPath = false;

    }

    Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
    Vector2 force = direction * speed * Time.deltaTime;

    rb.AddForce(force);

    float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

    if (distance < nextWaypointDistance)
    {
        currentWayPoint++;
    }

if (enemyGFX!=null)
{
    if (rb.velocity.x >= 0.01f)
        {

            enemyGFX.localScale = new Vector3(-4f, 4f, 1f);
            lookingRight = false;
        }
        else if (rb.velocity.x <= -0.1f)
        {

            enemyGFX.localScale = new Vector3(4f, 4f, 1f);
            lookingRight = true;


        }

}

}




}
