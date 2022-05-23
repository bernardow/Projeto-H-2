using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<String> _Montados = new List<String>();
    private bool _BtnPressed = false;
    private CatchAndRelease _CR = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _CR = FindObjectOfType<CatchAndRelease>();
    }

    // Update is called once per frame
    void Update()
    {
        _BtnPressed = _CR._SendOrder;
    }

    private void CheckOrder()
    {
        if (_BtnPressed)
        {
            
        }
    }
    
}

