using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Transform[] Locals;
    public GameObject[] Ingredients;
    public GameObject CanvasIngredients;
    public GameObject[] FolhaPedido;
    public List<GameObject> Instanciados;  

    public int num = 0;
    public int numSort;
    public int timesToRepeat;

    [SerializeField] private GameObject [] _newObjs;

    public bool rand = false;
    public bool go = true;

    void Update()
    {
        if (go)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int y = 0; y < FolhaPedido.Length; y++)
                {
                    FolhaPedido[y].SetActive(true);
                }
                Order();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                for (int y = 0; y < FolhaPedido.Length -1; y++)
                {
                    FolhaPedido[y].SetActive(false);
                    Destroy(Instanciados[y]);
                    Debug.Log(y);
                }              
            }
        }

        void Order()
        {
            for (int k = 0; k < FolhaPedido.Length; k++)
            {
                FolhaPedido[k].SetActive(true);
            }
/*
            for (int j = 0; j < _newObjs.Length; j++)
            {
                Destroy(_newObjs[j]);
            }
*/
            timesToRepeat = Random.RandomRange(0, Ingredients.Length);
            int i = 0;

            while (i <= timesToRepeat)
            {
                if (num >= 3)
                {
                    num = 0;
                }

                if (i > timesToRepeat)
                    break;

                numSort = Random.Range(0, Ingredients.Length);


                GameObject _obj = Instantiate(Ingredients[numSort], Locals[num].transform.position, Locals[num].transform.rotation);
                //_obj.tag = "Pedido";
                _obj.transform.SetParent(CanvasIngredients.transform);
                Instanciados.Add(_obj);


                i++;
                num++;
            }
        }
    }
}
