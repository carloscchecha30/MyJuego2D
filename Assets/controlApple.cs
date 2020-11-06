using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlApple : MonoBehaviour {
    
   
 
       private  void OnTriggerEnter2D(Collider2D other){
           if(other.gameObject.name.Equals("goblin archer")) {
              
             ControlPersonaje ctr = other.gameObject.GetComponent<ControlPersonaje>();           
          Destroy(gameObject);
         
          ctr.addPuntaje();
           }  
      
      }
}
