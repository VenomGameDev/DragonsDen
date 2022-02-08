using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private float WaitForSeconds = 2f;
    [SerializeField] private int enemyCountLimit = 10;
    private int count = 2;

    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    private GameObject[] getCount;
    private bool EnemeySpawned = false;

    public void Start()
    {

        EnemeySpawned = false;

    }



    public void Update()
    {
        //Takes the # of Enemeies and stores it in "count"
        getCount = GameObject.FindGameObjectsWithTag("Bandit");
        count = getCount.Length;

        //Respawn Limit/Generator w/ Time Delay
        if ((count < enemyCountLimit) && (EnemeySpawned == false))
        {

            SpawnNewEnemy();
            EnemeySpawned = true;
            count = getCount.Length;
            StartCoroutine(myDelay());

        }

        //IE Function to delay respawn times
           IEnumerator myDelay()
        {
            // waits for two seconds before continuing
            yield return new WaitForSeconds(WaitForSeconds);

            if (EnemeySpawned == true)
            {

                EnemeySpawned = false;
            }


        }

    }


    //Enemy Spawn Function
    public void SpawnNewEnemy()
    {

        //Spawns enemies randomly depending on spawn location
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length - 1));

        Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber].transform.position, Quaternion.identity);



    }
}
