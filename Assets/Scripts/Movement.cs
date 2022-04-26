using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour, IPointerDownHandler {
    [SerializeField] float speed = 5;
    [SerializeField] Controller controller;
    Vector3 dir;

    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("PointerDown");
    }
    private void Update(){
        dir = controller.GetDir();
        transform.position += dir * speed * Time.deltaTime;
    }
}
