using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour
{
    //vitesse de rotation de la main
    [SerializeField]
    private float rotSpeed;

    
   
    
    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame

    public void MoveZ()
    {

        transform.Rotate(new Vector3(0, 0, rotSpeed));

        Debug.Log("Main_Z_avec_botton");

    }
    public void MoveS()
    {

        transform.Rotate(new Vector3(0, 0, -rotSpeed));

        Debug.Log("Main_S_avec_botton");

    }
    void Update()
    {
     //MainDéplacement_______________________________________________________________MainDéplacement

        //si j'appuie sur Z je rotate la main 
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(new Vector3(0, 0, rotSpeed) );

            Debug.Log("Main_Z ");
        }
        //si j'appuie sur S je rotate la main 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, - rotSpeed));

            Debug.Log("Main_S ");
        }
        
     //MainDéplacement_______________________________________________________________MainDéplacement





    }





}
