using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    private int minEnemyAmount = 6;
    private int enemyAmount = 0;

    private void Start(){
        GameEvents.current.OnEnemiesDeath += EnemiesDeath;
        enemyAmount = Random.Range(minEnemyAmount, enemies.Count);
        for(int i = 0; i < enemyAmount; i++) {
            enemies[i].SetActive(true);
            enemies[i].transform.position = new Vector3(Random.Range(-3f,3f), 0, Random.Range(4f,9f));
            enemies[i].transform.localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0,180f), 0));
        }
    }

    private void EnemiesDeath(int amount) {
        enemyAmount -= amount;
        if(enemyAmount <= 0) {
            GameEvents.current.OnEnemiesDeath -= EnemiesDeath;
            GameEvents.current.LevelWin();
        }
    }

}
