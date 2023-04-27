using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileController : MonoBehaviour
{

    [Header("Pile Options")]
    [SerializeField] private Transform pileAnchor;
    [SerializeField] private float spaceBetweenEnemies = 0.25f;
    [SerializeField] private float followSpeed = 0.5f;
    [SerializeField] private float rotationAmount = 15f;

    private List<Transform> enemyPile = new List<Transform>();
    private float xRot = 0;

    private bool throwAway = false;
    private float throwForce = 7.5f;

    private void Start() {
        GameEvents.current.OnAddEnemyToPile += AddEnemyToPile;
        GameEvents.current.OnReloadLevel += ResetEvents;
        GameEvents.current.OnNextLevel += ResetEvents;
        GameEvents.current.OnEnemiesToDarkHole += EnemiesToDarkHole;
        enemyPile.Add(pileAnchor);
    }

    private void Update(){
        for (int i = 1; i < enemyPile.Count; i++){
            Transform currentObj = enemyPile[i];
            currentObj.position = Vector3.Lerp(currentObj.position, new Vector3(enemyPile[i - 1].position.x, currentObj.position.y, enemyPile[i - 1].position.z), Time.deltaTime * followSpeed);
            currentObj.rotation = Quaternion.LookRotation(enemyPile[0].forward, Vector3.up);
            xRot = (Mathf.Pow(i,(2f))) * (-(rotationAmount/enemyPile.Count)/**(1-(2*(i%2)))*/) * Vector3.Distance(currentObj.position, new Vector3(enemyPile[i - 1].position.x, currentObj.position.y, enemyPile[i - 1].position.z));
            if(xRot < -90) {
                xRot = -90f;
            }
            currentObj.rotation = Quaternion.Euler(currentObj.rotation.eulerAngles + new Vector3(xRot,0,0) /*+ new Vector3(0,180*(i%2),0)*/);
        }
        if(!throwAway) {
            return;
        }
        GameEvents.current.EnemiesDeath(enemyPile.Count-1);
        for(int i = enemyPile.Count-1; i >= 1; i--) {
            ThrowEnemy(enemyPile[i].gameObject);
            enemyPile.RemoveAt(i);
        }
        throwAway = false;
    }

    public void AddEnemyToPile(EnemyBodyCollision enemy) {
        if(enemyPile.Count > GameManager.Instance.MaxPileSize) {
            return;
        }
        GameManager.Instance.CurrentPileSize += 1;
        enemy.SetPileInfo(pileAnchor.position + new Vector3(0f, spaceBetweenEnemies * (enemyPile.Count-1), 0f), pileAnchor, enemyPile.Count);
        enemyPile.Add(enemy.GetFather());
        GameEvents.current.EnemyAddedToPile();
    }

    private void EnemiesToDarkHole() {
        throwAway = true;;
    }

    private void ThrowEnemy(GameObject enemy) {
        enemy.gameObject.layer = 10;
        enemy.gameObject.AddComponent<Rigidbody>();
        enemy.gameObject.AddComponent<SphereCollider>();
        enemy.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,1f,1f) * throwForce;
        enemy.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(30f,90f),0,0));
        Destroy(enemy.gameObject, 5f);
    }

    private void ResetEvents() {
        for(int i = enemyPile.Count-1; i >= 1; i--) {
            enemyPile.RemoveAt(i);
        }
    }
}
