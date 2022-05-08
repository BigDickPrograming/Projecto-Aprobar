using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public Entity entity;

    // Update is called once per frame
    void Update(){
        transform.position = new Vector3(entity.transform.position.x,
            transform.position.y, entity.transform.position.z - 20f);
    }
}
