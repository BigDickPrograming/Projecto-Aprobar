using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Entity {
    [SerializeField] RockBullet rockBulletPrefab;
    [SerializeField] Controller controller;
    [SerializeField] Transform prefabPositionTransform;
    public override void Death(){
        EventManager.TriggerEvent(EVENT.WINGAME);
    }

    public void CreateBullet(){
        CreateRockBullet(prefabPositionTransform.position, CalculateFuturePosition());
    }
    void CreateRockBullet(Vector3 pos, Vector3 desired){
        RockBullet bullet = Instantiate(rockBulletPrefab);
        bullet.transform.position = pos;
        bullet.ApplyForce(desired);
    }

    Vector3 CalculateFuturePosition(){
        Vector3 desired = new Vector3();
        Vector3 futurePosition = new Vector3();
        futurePosition += Player.PlayerTransform.position + controller.GetDir();
        desired -= transform.position;
        desired = futurePosition - transform.position;
        return desired;
    }
}
