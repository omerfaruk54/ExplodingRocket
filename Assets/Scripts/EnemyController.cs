using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private GameObject[] enemyPrefab; // d��man�n prefab�

    [SerializeField] private float spawnDelay = 2f; // her spawn aras� bekleme s�resi
    [SerializeField] private float moveSpeed = 5f; // d��man�n hareket h�z�
    [SerializeField] private float nextSpawnTime = 5f; // bir sonraki spawn zaman�
    [SerializeField] private float spawnY_Up, spawnY_Down;
    [SerializeField] private Transform newTransform; // Yeni transform

    [SerializeField] private float nextSpawnTime2 = 5f; // bir sonraki spawn zaman�







    void FixedUpdate()
    {
        EnemySpawner();
    }



    private void EnemySpawner()
    {
        if (Time.time >= nextSpawnTime)
        {
            float spawnY = Random.Range(spawnY_Up, spawnY_Down);

            GameObject newEnemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], newTransform.position, Quaternion.identity);
            newEnemy.transform.position = new Vector3(transform.position.x, spawnY, 0);
            newEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;

            nextSpawnTime = Time.time + spawnDelay;
        }

        // etiketi "Enemy" olan t�m nesneleri topla
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x < -10f) // x koordinat� -10'dan k���kse
            {
                Destroy(enemy); // nesneyi yok et
                gameManager.AddPoints(Random.Range(1,15));
                gameManager.scoreText.text = "" + gameManager.score;
                    
            }
        }


        if (gameManager.score >= 50)
        {
            moveSpeed = 10f;
            spawnDelay = 1.5f;
        }

        if (gameManager.score >=100)
        {
            moveSpeed = 15f;
            spawnDelay = 1f;
        }

        if (gameManager.score >= 200)
        {
            moveSpeed = 20f;
            spawnDelay = 0.7f;

            if (Time.time >= nextSpawnTime2)  //ikinci nesne olu�muyor �uan
            {
                float spawnY = Random.Range(spawnY_Up, spawnY_Down);

                GameObject newEnemy2 = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], newTransform.position, Quaternion.identity);
                newEnemy2.transform.position = new Vector3(transform.position.x, spawnY, 0);
                newEnemy2.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;

                nextSpawnTime2 = Time.time + spawnDelay;
            }

        }

    }
}
