using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Je suis la pour activer le cone
        
        
    }


    private void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.tag == "player")
        {

            Debug.Log("detect");

            
        }

    }


    void Update()
    {

      




    }
    
}

