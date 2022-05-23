using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BurgerModel : MonoBehaviour
{
    private GameManager _GM = null;
    // Start is called before the first frame update
    void Start()
    {
        _GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (tag != "Montado")
            {
                if (collision.gameObject.CompareTag("Montado") || collision.gameObject.CompareTag("Bandeja"))
                {
                    tag = "Montado";
                    _GM._Montados.Add(gameObject.name);
                }
            }
        }
    }
}
