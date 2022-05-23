using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<String> _Ingredients = new List<string>();
    public List<String> _Order = new List<string>();
    [SerializeField] private float _Timer = 0f;
    [SerializeField] private int _LimitePorFase = 0;
    [SerializeField] private int _MinimoPorFase = 0;
    [SerializeField] private GameObject _Comanda = null;
    [SerializeField] private TextMeshProUGUI _OrderText = null;
    private float _TslOrder = 0f;
    private bool _SetTimer = false;
    private string _PedidoTeste = "";
    
    // Update is called once per frame
    void Update()
    {
        RNG();
    }

    private void RNG()
    {
        if(Input.GetKeyDown(KeyCode.E))
            _SetTimer = true;
        
        if (_SetTimer)
        {
            _TslOrder += Time.deltaTime;

            if (_TslOrder > _Timer)
            {
                Comanda();
                _TslOrder = 0f;
                _SetTimer = false;
            }
        }
    }

    private void SubRNG()
    {
        int pedido = Random.Range(0, 0);

        switch (pedido)
        {
            case 0 :
                _Order.Clear();
                _Order.Add(_Ingredients[0]);
                _Order.Add(_Ingredients[1]);
                int quantidadeDeItens = Random.Range(_MinimoPorFase, _LimitePorFase);
                for(int i = 0; i <= quantidadeDeItens; i++)
            {
                _Order.Add(_Ingredients[Random.Range(2,4)]);
            }
                break;
            case 1 : _PedidoTeste = (_Ingredients[0].ToString() + _Ingredients[1].ToString());
                break;
            case 2 : _PedidoTeste = (_Ingredients[0].ToString() + _Ingredients[1].ToString());
                break;
            default: Debug.Log("erro");
                break;
        }
    }

    private void Comanda()
    {
        SubRNG();
        GameObject newComanda = Instantiate(_Comanda, transform.position, quaternion.identity);
        TextMeshProUGUI newText = newComanda.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        Comanda cm = newComanda.gameObject.GetComponent<Comanda>();
        _OrderText = newText;
        int orderCount = _Order.Count;
        _OrderText.text = _Order[0];
        _OrderText.text += "\n";
        for (int i = 1; i < orderCount; i++)
        {
            _OrderText.text += _Order[i];
            _OrderText.text += "\n";
        }

        foreach (String ingredient in _Order)
        {
            cm._ComandList.Add(ingredient);
        }
    }
}
