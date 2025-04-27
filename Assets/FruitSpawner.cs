using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    public static FruitSpawner Instance;

    public GameObject[] fruitPrefabs;
    public GameObject bombPrefab;

    public float spawnInterval = 1.5f;
    private bool canSpawn = true;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnFruitsRoutine());
    }

    public void DelaySpawnForSeconds(float seconds)
    {
        canSpawn = false;
        StartCoroutine(DelayRoutine(seconds));
    }

    IEnumerator DelayRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canSpawn = true;
    }

    IEnumerator SpawnFruitsRoutine()
    {
        while (true)
        {
            if (canSpawn)
            {
                int count = Random.Range(1, 7); // spawn từ 1 đến 6 object
                for (int i = 0; i < count; i++)
                {
                    SpawnRandomFruit();
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomFruit()
    {
        GameObject prefab;
        float chance = Random.value;

        // 15% khả năng là bomb
        if (chance < 0.15f)
        {
            prefab = bombPrefab;
        }
        else
        {
            prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        }

        // Spawn tại X ngẫu nhiên trong [-8, 8], Y cố định là -6
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), -6f);
        GameObject fruit = Instantiate(prefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();

        // Tính toán vận tốc chéo (lực đẩy lên + lực đẩy ngang ngẫu nhiên)
        float forceX = Random.Range(-3f, 3f);  // Bay ngang nhẹ trái/phải
        float forceY = Random.Range(12f, 18f); // Bay cao lên mạnh

        rb.linearVelocity = new Vector2(forceX, forceY);

        // Quay xoay khi bay
        rb.angularVelocity = Random.Range(-300f, 300f);
    }
}
