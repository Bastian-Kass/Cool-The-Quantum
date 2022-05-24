using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShieldCollision : MonoBehaviour
{

   Stack<LaserCollisionExplosion> ExplosionStack;
   public GameObject explosionAnimationPrefab;
   

   void Awake(){
      ExplosionStack = new Stack<LaserCollisionExplosion>();
   }

   void FixedUpdate() { 
      LaserCollisionExplosion explosion;
      GameObject explotionFX;

      while(ExplosionStack.Count > 0){
         explosion = ExplosionStack.Pop();

         explosion.AddExplosionForce();

         explotionFX = UnityEngine.GameObject.Instantiate( explosionAnimationPrefab, explosion.position, Quaternion.identity);

         UnityEngine.Object.Destroy(explotionFX, 5f);
      }

   } 

   void OnCollisionEnter(Collision collision) {  

      if(collision.gameObject.CompareTag("HeatParticle")){
         ExplosionStack.Push(new LaserCollisionExplosion(collision.GetContact(0).point, collision.rigidbody));
      }

   } 


}

public class LaserCollisionExplosion{
   public Vector3 position;
   public Rigidbody _rigidbody;

   public float radius = 1f; 
   public float power = 300.0F; 
   public float lift = 0; 
   public float speed = 10; 

   public LaserCollisionExplosion(Vector3 position, Rigidbody _rigidbody){
      this.position = position;
      this._rigidbody = _rigidbody;
   }

   public void AddExplosionForce(){
      _rigidbody.AddExplosionForce(power, position, radius, lift);
   }


}