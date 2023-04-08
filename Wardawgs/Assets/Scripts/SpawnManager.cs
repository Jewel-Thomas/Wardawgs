using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject meteors;
    public GameObject bigMeteors;
    public GameObject YellowPowerUp;
    public GameObject RedPowerUp;
    public GameObject BluePoweUp;
    public Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",0.5f,1f);
        InvokeRepeating("SpawnBigEnemy",10f,10f);
        InvokeRepeating("SpawnYellowPowerUp",15f,15f);
        InvokeRepeating("SpawnRedPowerUp",20f,20f);
        InvokeRepeating("SpawnBluePowerUp",25f,20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.isAlive)
        {
            CancelInvoke();
        }
    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(-3.75f,3.75f);
        startPosition.x = randomX;
        Instantiate(meteors,startPosition,Quaternion.identity);
    }

    void SpawnBigEnemy()
    {
        float randomXBig = Random.Range(-3f,3f);
        Instantiate(bigMeteors,startPosition,Quaternion.identity);
    }

    void SpawnYellowPowerUp()
    {
        float randomX = Random.Range(-3.75f,3.75f);
        startPosition.x = randomX;
        Instantiate(YellowPowerUp,startPosition,Quaternion.identity);
    }

    void SpawnRedPowerUp()
    {
        float randomX = Random.Range(-3.75f,3.75f);
        startPosition.x = randomX;
        Instantiate(RedPowerUp,startPosition,Quaternion.identity);
    }

    void SpawnBluePowerUp()
    {
        float randomX = Random.Range(-3.75f,3.75f);
        startPosition.x = randomX;
        Instantiate(BluePoweUp,startPosition,Quaternion.identity);
    }
}
