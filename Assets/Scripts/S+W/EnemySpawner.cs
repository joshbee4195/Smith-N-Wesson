using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public int spawnCount;
    public Transform spawnPoint;

    public GameObject grass;
    public Transform grassSpawn;

    public GameObject barrier;
    public float longestBarrierPos;
    public GameObject player;


    public bool adjusted;
    public bool adjusted2;
    public bool adjusted3;
    public bool adjusted4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gen.gameOver != true)
        {
            if (Time.frameCount % spawnCount == 0)
            {
                //move spawn point
                // spawnPoint.transform.position.z + 
                spawnPoint.transform.position = new Vector3(Random.Range(-5, 5), spawnPoint.transform.position.y, Random.Range(15, 50.1f));
                //spawn enemy
                Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            }


            if (player.transform.position.z > longestBarrierPos)
            {
                //      barrier.transform.position = player.transform.position - new Vector3(0, 0, 1);

                //    longestBarrierPos = player.transform.position.z;
            }


            if (grassSpawn.transform.position.z - player.transform.position.z < 200)
            {
                //    Instantiate(grass, grassSpawn.transform.position, Quaternion.identity);

                //   grassSpawn.transform.position += new Vector3(0, 0, 30);
            }

            if (gen.points > 500)
            {
                if (!adjusted)
                {
                    spawnCount = spawnCount / 2;

                    adjusted = true;

                }
            }

            if (gen.points > 1000)
            {
                if (!adjusted2)
                {
                    spawnCount = spawnCount / 2;

                    adjusted2 = true;

                }
            }

            if (gen.points > 2000)
            {
                if (!adjusted3)
                {
                    spawnCount = spawnCount / 2;

                    adjusted3 = true;

                }
            }

            if (gen.points > 4000)
            {
                if (!adjusted4)
                {
                    spawnCount = spawnCount / 2;

                    adjusted4 = true;

                }
            }
        }
    }
}
