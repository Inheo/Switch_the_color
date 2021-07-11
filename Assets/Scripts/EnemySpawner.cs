using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    private List<Transform> transformEnemies = new List<Transform>();
    private Queue<Enemy> enemies = new Queue<Enemy>();

    void Awake()
    {
        PullEnemies();
    }
    private void OnEnable()
    {
        PutStartPositionEnemies();
        StartCoroutine(ShowEnemy());
    }

    private void PullEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform);
            enemy.gameObject.SetActive(false);
            transformEnemies.Add(enemy.transform);
            enemies.Enqueue(enemy);
        }
    }


    private void Spawn()
    {
        enemies.Peek().gameObject.SetActive(true);
        enemies.Peek().transform.localPosition = Vector3.zero;
        //enemies.Peek().SetColor();
        enemies.Enqueue(enemies.Dequeue());

    }

    private void PutStartPositionEnemies()
    {
        for (int i = 0; i < transformEnemies.Count; i++)
        {
            transformEnemies[i].localPosition = Vector3.zero;
            transformEnemies[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator ShowEnemy()
    {
        while (!Game.isGameover)
        {
            Spawn();
            yield return new WaitForSeconds(0.6f * (EnemyMovement.StartSpeed / EnemyMovement.Speed));
        }
    }
}
