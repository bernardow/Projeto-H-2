using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMechanic : MonoBehaviour
{
    public int valorMin = 0;
    public int valorMax = 50;

    public int numeroSorteado;
    [Space(20)]
    public List<int> numerosJaSorteados = new List<int>();

    List<int> numeros = new List<int>();

    void Start()
    {
        for (int x = valorMin; x <= valorMax; x++)
        {
            numeros.Add(x);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && numeros.Count > 0)
        {
            GerarNumerosAleatorios();
        }
    }

    void GerarNumerosAleatorios()
    {
        int indice = Random.Range(0, numeros.Count);
        numeroSorteado = numeros[indice];
        numerosJaSorteados.Add(numeroSorteado);
        numeros.Remove(numeros[indice]);
    }
}
