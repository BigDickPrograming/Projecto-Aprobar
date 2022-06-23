using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colitiondetecter : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("colision estratosferica");
    }
    void Update()
    {
    }
}
