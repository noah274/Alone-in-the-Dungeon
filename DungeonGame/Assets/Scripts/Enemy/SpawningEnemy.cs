using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawningEnemy : MonoBehaviour
{
    private System.Random _random = new System.Random();
    private GeneratorOptions gOptions;
    private int roomNumber;
    private bool endetSpawning = false;
    private GenerateRoom roomObj;
    public void StartSpawningEnemies(GeneratorOptions gOptions,int roomNumber)
    {
        this.gOptions = gOptions;
        this.roomNumber = roomNumber;

        int level = gOptions.layerLevel;
        int enemyCount = _random.Next((level + 3), ((level + 4)* 2));
        
        StartCoroutine(WaitForASecondToSpawnEnemy(enemyCount));
    }
    

    
    private IEnumerator WaitForASecondToSpawnEnemy(int enemyCount)
    {
        yield return new WaitForSeconds(1f);


        if (!isRoomDone(roomNumber))
        {
            //Debug.Log("EnemyCount: " + enemyCount);

        
            Debug.Log("RoomNumber: " + roomNumber + " - Roomtype: " + roomObj.GetRoomType() + " - EnemyCount: " + enemyCount);
        
            if (roomObj.GetRoomType() == gOptions.bossRoom)
            {
                //Debug.Log("Bossroom");
                SpawnBoss();
            }
            else
            {
                StartSpawning(enemyCount);   
            }
        }
    }
    
    private bool isRoomDone(int number)
    {
        string roomCenterPointPrefix = "RoomCenterPoint_" + number.ToString();
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gameObjects)
        {
            if (obj.name == roomCenterPointPrefix)
            {
                GenerateRoom roomObj = obj.GetComponent<RoomReference>().room;
                this.roomObj = roomObj;
                return roomObj.GetRoomDone();
            }
        }

        return false;
    }
    
    

    private void Update()
    {
        if (endetSpawning)
        {
            CheckIfRoomDone();   
        }
    }


    private void CheckIfRoomDone()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    
        if (enemies.Length == 0)
        {
            endetSpawning = false;
            
            RoomLogic logic = FindObjectOfType<RoomLogic>();
            if (logic != null)
            {
                logic.OpenRoom(roomNumber);
            }
            else
            {
                Debug.LogError("Error: Main script not found!");
            }
        }
    }

    private IEnumerator WaitForAttack(GameObject enemy)
    {
        yield return new WaitForSeconds(2f);
        
        enemy.GetComponent<BossAI>().StartAttack();
    }

    private void SpawnBoss()
    {
        GameObject targetRoom = GameObject.Find("RoomCenterPoint_" + roomNumber.ToString());
        GameObject enemy = Instantiate(gOptions.bossEnemy, targetRoom.transform.position, Quaternion.identity);
        enemy.tag = "EnemyBoss";
        GameObject createdObjectsContainer = GameObject.Find("createdObjects");
        enemy.transform.SetParent(createdObjectsContainer.transform);

        enemy.GetComponent<BossAI>().hitPoints = enemy.GetComponent<BossAI>().hitPoints + (gOptions.layerLevel * gOptions.healthMultiplier);
        enemy.GetComponent<BossAI>().damage = enemy.GetComponent<BossAI>().damage * (gOptions.layerLevel * gOptions.damageMultiplier);
        
        StartCoroutine(WaitForAttack(enemy));
    }


    private void StartSpawning(int enemyCount)
    {
        StartCoroutine(SpawnEnemies(enemyCount));
    }

    private IEnumerator SpawnEnemies(int enemyCount)
    {
        GameObject targetRoom = GameObject.Find("RoomCenterPoint_" + roomNumber.ToString());
        Vector3 centerPos = targetRoom.transform.position;

        int enemyPlaced = 0;
        int circleRadius = gOptions.spawnRange;

        for (int i = 0; i < enemyCount + 1; i++)
        {
            if (enemyPlaced < enemyCount)
            {
                enemyPlaced++;

                float randomOffsetX = _random.Next(-circleRadius, circleRadius);
                float randomOffsetY = _random.Next(-circleRadius, circleRadius);

                Vector3 enemySpawnPos = centerPos + new Vector3(randomOffsetX, randomOffsetY, 0);
                Vector3Int tilemapPos = gOptions.gridFloor.WorldToCell(enemySpawnPos);

                if (!gOptions.gridFloor.HasTile(tilemapPos))
                {
                    //Debug.Log("No tile at spawn position, generating new position.");
                    i--;
                    enemyPlaced--;
                }
                else
                {
                    GameObject enemy = Instantiate(gOptions.enemy[_random.Next(0, gOptions.enemy.Length)], enemySpawnPos, Quaternion.identity);
                    enemy.tag = "Enemy";
                    GameObject createdObjectsContainer = GameObject.Find("createdObjects");
                    enemy.transform.SetParent(createdObjectsContainer.transform);
                    
                    enemy.GetComponent<EnemyAI>().hitPoints = enemy.GetComponent<EnemyAI>().hitPoints + (gOptions.layerLevel * gOptions.healthMultiplier);
                    enemy.GetComponent<EnemyAI>().damage = enemy.GetComponent<EnemyAI>().damage * (gOptions.layerLevel * gOptions.damageMultiplier);

                    float randomDelay = Random.Range(0, gOptions.spawnDelay);
                    yield return new WaitForSeconds(randomDelay);
                }
            }
            else
            {
                endetSpawning = true;
            }
        }
    }



}
