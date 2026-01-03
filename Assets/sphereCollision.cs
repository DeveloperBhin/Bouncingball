
using UnityEngine;

public class sphereCollision : MonoBehaviour
{
public SphereBehavior movement;
   void OnCollisionEnter (Collision collisionInfo){
   if(collisionInfo.collider.tag == "Obstacle"){
movement.enabled = false;
   }
   }
}
