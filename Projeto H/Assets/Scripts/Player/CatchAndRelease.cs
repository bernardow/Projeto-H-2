using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAndRelease : MonoBehaviour
{
    public string[] TagsSegurar;
    public string[] TagsSoltarBandeja;
    public string[] TagsSoltarGrill;
    public GameObject ObjSegurando;
    [Space(20)]
    public float DistanciaMax;
    public bool Segurando;
    public GameObject LocalSegurando;
    public LayerMask Layoso;
    public RaycastHit Hit;
    public GameObject LocalBandeja;
    public GameObject LocalGrill;
    public bool _SendOrder = false;
    
    void Update()
    {
        if (Segurando == true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out Hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position, Hit.point, Color.green);

                if (Input.GetMouseButtonDown(0))
                {
                    for (int x = 0; x < TagsSoltarBandeja.Length; x++)
                    {
                        if (Hit.transform.gameObject.tag == TagsSoltarBandeja[x])
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                ObjSegurando.transform.position = LocalBandeja.transform.position;
                                Segurando = false;
                                ObjSegurando.transform.parent = null;
                                ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
                                ObjSegurando = null;
                                return;
                            }
                            return;
                        }
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    for (int x = 0; x < TagsSoltarGrill.Length; x++)
                    {
                        if (Hit.transform.gameObject.tag == TagsSoltarGrill[x])
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                ObjSegurando.transform.position = LocalGrill.transform.position;
                                Segurando = false;
                                ObjSegurando.transform.parent = null;
                                ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
                                ObjSegurando = null;
                                return;
                            }
                            return;
                        }
                    }

                }

            }           
        }

        if (Segurando == false)
        {
            //RaycastHit Hit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward, out Hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position, Hit.point, Color.green);
                if (Hit.collider.gameObject.CompareTag("Botao") && Input.GetMouseButtonDown(0))
                    _SendOrder = true;
                
                ObjSegurando = Hit.transform.gameObject;
                for (int x = 0; x < TagsSegurar.Length; x++)
                {
                    if (Hit.transform.gameObject.tag == TagsSegurar[x])
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Segurando = true;
                            ObjSegurando = Hit.transform.gameObject;
                            if (ObjSegurando.GetComponent<Rigidbody>())
                            {
                                ObjSegurando.GetComponent<Rigidbody>().isKinematic = true;
                                ObjSegurando.transform.position = LocalSegurando.transform.position;
                                ObjSegurando.transform.rotation = LocalSegurando.transform.rotation;
                                ObjSegurando.transform.parent = LocalSegurando.transform;
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}



