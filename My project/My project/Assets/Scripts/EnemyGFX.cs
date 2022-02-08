using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{

    public AIPath aiPath;
    public bool lookingRight = false;


    // Update is called once per frame
    void Update()
    {

        if (aiPath.desiredVelocity.x >= 0.01f)
        {

            transform.localScale = new Vector3(-1f, 1f, 1f);
            lookingRight = false;
        }
        else if (aiPath.desiredVelocity.x <= -0.1f)
        {

            transform.localScale = new Vector3(1f, 1f, 1f);
            lookingRight = true;


        }


        



    }
}
