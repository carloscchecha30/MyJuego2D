using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPersonaje : MonoBehaviour {
      Rigidbody2D rgb;
      Animator anim;
      public float maxVel=5f;
      bool haciaDerecha=true;

     public bool betterJump =false;
     public float fallMultiplier =0.5f;
     public float lowJumpMultiplier=1f;
     public int puntaje=0;
     public int energy =  5;


      public bool jumping = false;
    public float yJumpForce = 300;
     Vector2 jumpForce;
    
    
     AudioSource aSource;
    public AudioClip sonido;
    public AudioClip ouch;
    public AudioClip dying;
    public AudioClip ganar;

   
    public Text textEnergy; 
    public Text txt;
    public Text  textGameOver;
    public Text textpf;
    public bool juegoTerminado=false;
     
   
	void Start () {
	 rgb = GetComponent<Rigidbody2D>();	
         anim = GetComponent<Animator>();
         jumpForce = new Vector2(0, 0);
        txt.text= puntaje.ToString();
        textEnergy.text= energy.ToString();
         aSource = GetComponent<AudioSource>();
	}
	

        void Upadate(){
         
       txt.text= puntaje.ToString();
       textEnergy.text= energy.ToString(); 

    

         }
      
     
        
	
	void FixedUpdate () {
	float v=Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0,rgb.velocity.y);
         v*=maxVel;
        vel.x=v;
        rgb.velocity=vel;
        anim.SetFloat("speed",vel.x);

          if(haciaDerecha && v<0){
             haciaDerecha=false;
             Flip();
          }else if(!haciaDerecha && v>0){
            haciaDerecha=true;
           Flip();   
            }

             if(Input.GetAxis("Jump")>0.01){
                 if(juegoTerminado){
                  SceneManager.LoadScene("principal");
                   }
                  else{

                    if(!jumping){
                    jumping=true;
                    jumpForce.x=0f;
                    jumpForce.y=yJumpForce;
                    rgb.AddForce(jumpForce);
                                

               }else{
                 jumping=false;}

                }
               }



	}

       public void addPuntaje(){

        if(puntaje==15){
           textGameOver.text="Felicidades";
           textpf.text=puntaje.ToString();
           //Time.timeScale=0;
           aSource.PlayOneShot(ganar);
           juegoTerminado=true;
        
           }else{
           puntaje++;
         txt.text= puntaje.ToString();
           aSource.PlayOneShot(sonido);
            }
       
       }

       public void chocarObstaculo(){
          
              if(energy==0){
          energy=-1;
         
          aSource.PlayOneShot(dying);
          textGameOver.text="Game Over";
           //Time.timeScale=0;
          juegoTerminado=true;
          puntaje=0;
        
      
         }else{
        
          energy--;
           textEnergy.text= energy.ToString();
            aSource.PlayOneShot(ouch);
               }

         
        }

      void Flip(){
      var s= transform.localScale;
         s.x*=-1;
        transform.localScale=s;
         }
}
