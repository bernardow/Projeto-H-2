using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public RaycastHit hitPosition;

    void Update()
    {
        
        if(Input.GetMouseButton (0))
        {
            Physics.Raycast(transform.position, transform.forward, out hitPosition, 100);
            hitPosition.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        

        /*
        if(Physics.Raycast(transform.position, transform.forward, out hitPosition, 40))
        {                     
            if(hitPosition.transform.gameObject.GetComponent<MeshRenderer> () != null)
            {
                    hitPosition.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;              
            }
            
        }
        */
    }

    void Start()
    {

    }
}
