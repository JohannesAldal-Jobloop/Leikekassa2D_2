using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuleSkript2D : MonoBehaviour
{
    public float fart;
    public float skade;
    public float maksRekkevidde;

    private GameObject spelerGO;

    private Vector2 opprinnelsePos;

    private Rigidbody2D kulaRB;

    private KuleRestriksjoner kuleRestriksjoner;

    void Start()
    {
        kulaRB = GetComponent<Rigidbody2D>();
        opprinnelsePos = spelerGO.transform.position;
    }

    void Update()
    {
        BevegFramover();
        kuleRestriksjoner.KuleRestriksjonerFunk(opprinnelsePos, maksRekkevidde, gameObject);
    }

    void BevegFramover()
    {
        kulaRB.velocity = Vector3.forward * fart * Time.deltaTime;
    }


}
