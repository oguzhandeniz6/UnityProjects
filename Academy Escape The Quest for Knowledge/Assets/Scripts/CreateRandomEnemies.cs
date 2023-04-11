using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomEnemies : MonoBehaviour
{
    [SerializeField]
    public GameObject[] enemyPrefabs;

    [SerializeField]
    public float enemySpawnCooldown = 5f;

    int minX = 20;
    int maxX = 35;
    int minY = 13;
    int maxY = 25;

    int xPos;
    int yPos;
    int playerX;
    int playerY;
    int enemyType;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(true)
        {
            playerX = (int)Mathf.Round(player.position.x);
            playerY = (int)Mathf.Round(player.position.y);

            xPos = Random.Range(playerX + minX, playerX + maxX);
            yPos = Random.Range(playerY + minY, playerY + maxY);

            enemyType = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[enemyType], new Vector3(xPos, yPos, 0), Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnCooldown);
        }
    }

}
