using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstaculo : MonoBehaviour {

       


       private  void OnTriggerEnter2D(Collider2D other){
           if(other.gameObject.name.Equals("goblin archer")) {
              
          ControlPersonaje ctr = other.gameObject.GetComponent<ControlPersonaje>();                       
          ctr.chocarObstaculo();
          
   
           }  
      
      }
}
