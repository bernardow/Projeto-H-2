using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BurgerGrill : MonoBehaviour
{
    private Material _ThisMat = null;
    [SerializeField][Range(0,1)] private float _GrillFloat = 1;
    private bool _StartGrill = false;
    public string _BurgerPoint = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _ThisMat = GetComponent<MeshRenderer>().sharedMaterial;
        _GrillFloat = _ThisMat.shader.FindPropertyIndex("ColorSlider") + 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        _ThisMat.SetFloat("_ColorSlider", _GrillFloat);

        if (_StartGrill && _GrillFloat <= 1)
        {
            _GrillFloat = _GrillFloat + 0.05f * Time.deltaTime;
        }
        CheckBurgerPoint();
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Grill"))
            _StartGrill = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag(("Grill")))
            _StartGrill = false;
    }

    private void CheckBurgerPoint()
    {
        if (_GrillFloat <= 0.49f)
            _BurgerPoint = "Raw";
        else if (_GrillFloat >= 0.5f && _GrillFloat <= 0.8f)
            _BurgerPoint = "On Point";
        else if (_GrillFloat > 0.81f)
            _BurgerPoint = "Done";
        
    }
}
