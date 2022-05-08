using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmovePatrol : IEMovement{
  public List<Transform> waypoints = new List<Transform>();
  float _speed;
  private int _waypointIndex;
  Transform transform;
    public void Emovement()
    {
     Vector3 dir = (waypoints[_waypointIndex].position - transform.position );   
     if (dir.magnitude < 0.1f){
         _waypointIndex++;
         if(_waypointIndex >= waypoints.Count){
             _waypointIndex = 0;
         }
     }
    
    transform.position += dir.normalized * _speed * Time.deltaTime;
    }
}
