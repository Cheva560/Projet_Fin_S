using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class Player_controller : MonoBehaviour
{
    //valeur de la vitesse 
    [SerializeField]
    private float speed;

    //valeur de la force du saut
    [SerializeField]
    private float jumpForce;


    [SerializeField]
    private float maxSpeed;

    //Droit de sauté ou non
    private bool Canjump = false;

    //j'ai un rigibody
    private Rigidbody rb;

    //Prend le trasforme spaxner 
    [SerializeField]
    private Transform Spawner;

    //prends transform player
    [SerializeField]
    private Transform player;

    //prend le trasform de Checkpoint 
    [SerializeField]
    private Transform CheckPoint;

    private bool isMoveDroitePress = false;

    private bool isMoveGauchePress = false;

    [SerializeField]
    private Button buttonDroitePress;

    [SerializeField]
    private Button buttonGauchePress;

    private bool btnPressed;



  




    void Start()
    {
        //Je suis le player
        gameObject.tag = "Player";
        Debug.Log("Hello je suis le player ");

        //j'ai un Rigibody
        rb = GetComponent<Rigidbody>();

        buttonDroitePress.onClick.AddListener(MoveDroitePress);

        buttonGauchePress.onClick.AddListener(MoveGauchePress);


    }
    private void MoveDroitePress()
    {
        isMoveDroitePress = true;
        Debug.Log(" isMoveDroitePress ");

    }
    private void MoveGauchePress()
    {
        isMoveGauchePress = true;
        Debug.Log(" isMoveGauchePress ");
    }
   


    private void OnCollisionEnter(Collision other)
    {

        //vérifie avec quel tag je suis en collision
        //Debug.Log(other.collider.tag);

        //ANTISAUT________________________________________________________________________________ANTISAUT

        //vérifie si le joueur est en collision avec le tag SOL afin d'empecher les sauts dans les airs
        if (other.collider.tag == "SOL")
        {
            Canjump = true;

            Debug.Log("je suis au sol ");

        }
        //ANTISAUT________________________________________________________________________________ANTISAUT

        //KILL__________________________________________________________________________________KILL

        //Si je touche un cone je suis Tp au respawn
        if (other.collider.tag == "Cone")
        {

            Debug.Log("je meurs merde");

            player.transform.position = Spawner.transform.position;

        }
        //KILL__________________________________________________________________________________KILL
    }


    public void MoveDroite()
    {

        //déplacement vers la Droite avec les botton interface 
        rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);

        Debug.Log("MOUVE_R avec un botton ");

        

    }
     public void MoveGauche()
    {

        //déplacement vers la Droite avec les botton interface 
        rb.AddForce(Vector3.left  * speed, ForceMode.VelocityChange);

        Debug.Log("MOUVE_G avec un botton ");
    }

    public void JumpBotton()
    {
        //saut avec les botton interface 
        if (Canjump )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            Debug.Log("Jump_avec_botton");

            Canjump = false;

            Debug.Log("j'ai sauté");


        }
    


    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            btnPressed = true;
            Debug.Log("MouseDown ");
        }
        if (Input.GetMouseButtonUp(0))
        {

            btnPressed = false;
            Debug.Log("MouseUp ");

        }
        if (btnPressed && buttonDroitePress == true)
        {
            MoveDroite();
        }

        if (btnPressed && buttonGauchePress == true)
        {
            MoveGauche();
        }


        //Déplacement__________________________________________________________________________Déplacement

        //déplacement vers la Droite
        if (Input.GetKey(KeyCode.D ))
        {
            rb.AddForce  (Vector3.right * Time.deltaTime * speed, ForceMode.VelocityChange);

            Debug.Log("MOUVE_R");
        }
        //déplacement vers la Gauche
        if (Input.GetKey(KeyCode.Q ))
        {
            rb.AddForce  ( Vector3.left * Time.deltaTime * speed, ForceMode.VelocityChange);

            Debug.Log("MOUVE_G");

        }
        //Déplacement__________________________________________________________________________Déplacement

        //Saut_________________________________________________________________________________SAUT

        //Si j'appuie sur Space je saute à condition que Canjump soit activé
        if (Input.GetKeyDown(KeyCode.Space) && Canjump == true )
        {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                Debug.Log("Jump");
                



        }
        // Quand je relache SPACE je passe CanJump à false pour ne pas sauter dans les airs 
        if (Input.GetKeyUp(KeyCode.Space) && Canjump == true)
        {
            Canjump = false;

            Debug.Log("j'ai sauté");




        }
        //Saut_________________________________________________________________________________SAUT




        //Stop ________________________________________________________________________________Stop

       //Quand je relache la touche de déplacemnt ma vélocity passe à 0 
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, 0, 0);

            //Debug.Log("Stop_R");
        }

        //Quand je relache la touche de déplacemnt ma vélocity passe à 0 
        if (Input.GetKeyUp(KeyCode.Q))
        {
            rb.velocity = new Vector3(0, 0, 0);

           // Debug.Log("Stop_G");

        }
        //Stop ________________________________________________________________________________Stop


     
















    }






}
