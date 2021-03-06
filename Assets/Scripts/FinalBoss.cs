using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : Entity {
    [SerializeField] RockBullet rockBulletPrefab;
    [SerializeField] Controller controller;
    [SerializeField] Transform prefabPositionTransform;
    [SerializeField] Lvl lvlToLoad = Lvl.one;
    public override void Death(){
        EventManager.TriggerEvent(EVENT.WINGAME, lvlToLoad);
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
        return VectorSinY(Player.PlayerTransform.position - transform.position);
    }

    Vector3 VectorSinY(Vector3 vec){
        return new Vector3(vec.x, 0f, vec.z);
    }
}