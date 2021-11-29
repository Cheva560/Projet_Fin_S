using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint_controlller : MonoBehaviour
{

    [SerializeField]
    private GameObject lux;

    [SerializeField]
    private Transform Spawner;



    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    //LUMIERECheckPoint____________________________________________________________________LUMIERECheckPoint
    private void OnCollisionEnter(Collision other)
    {
        // si je rentre en colision avec le tag player je tp le spawner sur ma position
        //et j'active une lumiere pour faire un retour visual au joueur 
        if (other.collider.tag == "Player")
        {

            Debug.Log("New respawnPoint");

            Spawner.transform.position = gameObject.transform.position;

            lux.SetActive(true);
        }

    }
    //LUMIERECheckPoint____________________________________________________________________LUMIERECheckPoint
}
