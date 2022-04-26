using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFactory : MonoBehaviour{
    public static SlimeFactory Instance {
        get {
            return _instance;
        }
    }
    static SlimeFactory _instance;
    public Slime slimePrefab;
    public int slimeStock = 5;
    public ObjectPool<Slime> pool;

    void Start(){
        _instance = this;
        pool = new ObjectPool<Slime>(SlimeCreator, Slime.TurnOn, Slime.TurnOff, slimeStock);
    }

    public Slime SlimeCreator(){
        return Instantiate(slimePrefab);
    }

    public void ReturnSlime(Slime s){
        pool.ReturnObject(s);
    }
}
