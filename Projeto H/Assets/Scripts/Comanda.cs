using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comanda : MonoBehaviour
{
    public List<String> _ComandList = new List<string>();
    private GameManager _GM = null;
    private CatchAndRelease _CR = null;

    private bool _BtnPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        _GM = FindObjectOfType<GameManager>();
        _CR = FindObjectOfType<CatchAndRelease>();
    }

    // Update is called once per frame
    void Update()
    {
        _BtnPressed = _CR._SendOrder;

        if (_BtnPressed)
        {
            if (_GM._Montados.Count == _ComandList.Count + 1)
            {
                for (int i = 0; i < _ComandList.Count; i++)
                {
                    if (_GM._Montados.Contains(_ComandList[0 + i]))
                    {
                        
                    }
                }
            }
        }
    }
}
