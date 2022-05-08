using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : Controller, IDragHandler, IEndDragHandler {
    [SerializeField] float maxMagnitude = 100;
    [SerializeField] CanvasGroup parent = null;
    Vector3 initPosition;
    Vector3 dir;

    private void Start(){
        initPosition = transform.position;
    }

    public override Vector3 GetDir(){
        return dir / maxMagnitude;
    }

    private void Update(){
        if (Input.touchCount > 0){
            if(Input.touches[0].phase == TouchPhase.Began){
                parent.alpha = 1;
                parent.transform.position = Input.touches[0].position;
                initPosition = transform.position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended){
                parent.alpha = 0;
            }
        }
    }

    public void OnDrag(PointerEventData eventData){
        dir = ordenarVector3(Vector3.ClampMagnitude((Vector3)eventData.position - initPosition, maxMagnitude));
        transform.position = initPosition + ordenarVector3(dir);
    }

    public void OnEndDrag(PointerEventData eventData){
        transform.position = initPosition;
        dir = Vector3.zero;
    }

    Vector3 ordenarVector3(Vector3 vec){
        return new Vector3(vec.x, vec.z, vec.y);
    }
}