using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{

    protected EnemyCtrl enemyCtrl;

    public void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }



    private void OnTriggerEnter2D(Collider2D collision) // collision : player tai DameS dang nam trong Enemy
    {
        DamageReceiver dameReceiver = collision.GetComponent<DamageReceiver>();
        if (dameReceiver == null) return;

        dameReceiver.Receive(1);

        this.enemyCtrl.despawner.Despawn();

        Debug.Log(collision.name);
    }
}
