using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("Layer Options")]
    [SerializeField] private LayerMask enemyUpLayer;
    [SerializeField] private LayerMask enemyBeCollectedLayer;
    [SerializeField] private LayerMask darkHoleLayer;

    private GameObject currentColliderObj;

    private void OnTriggerEnter(Collider other) {
        currentColliderObj = other.gameObject;
        if((enemyBeCollectedLayer.value & (1 << currentColliderObj.layer)) > 0) {
            GameEvents.current.AddEnemyToPile(other.gameObject.GetComponent<EnemyBodyCollision>());
        }else if((enemyUpLayer.value & (1 << currentColliderObj.layer)) > 0) {
            currentColliderObj.GetComponent<EnemyBodyCollision>().ThrowAway((currentColliderObj.transform.position - transform.position).normalized);
            GameEvents.current.EnemyPunched();
        }else if((darkHoleLayer.value & (1 << currentColliderObj.layer)) > 0) {
            GameManager.Instance.CurrentMoney += GameManager.Instance.CurrentPileSize * 5;
            GameManager.Instance.CurrentPileSize = 0;
            GameEvents.current.EnemiesToDarkHole();
        }
    }
}
