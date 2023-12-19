using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuleSkript2D : MonoBehaviour
{
    public float fart;
    public float skade;
    public float maksRekkevidde;

    private float spawnPositionX;
    private float spawnPositionY;

    private GameObject spelerGO;

    private Vector2 opprinnelsePos;

    private Rigidbody2D kulaRB;

    private KuleRestriksjoner kuleRestriksjoner;

    void Start()
    {
        //transform.parent = null;
        kulaRB = GetComponent<Rigidbody2D>();
        kuleRestriksjoner = GameObject.Find("SpelSjef").GetComponent<KuleRestriksjoner>();
        spelerGO = GameObject.Find("Speler");
        opprinnelsePos = spelerGO.transform.position;
    }

    void Update()
    {
        BevegFramover();
        //BulletRestriksjoner();
        kulaRB.gravityScale = 0.0f;
        //kuleRestriksjoner.KuleRestriksjonerFunk(opprinnelsePos, maksRekkevidde, gameObject);
    }

    void BevegFramover()
    {
        kulaRB.AddRelativeForce(Vector2.down * fart *Time.deltaTime, ForceMode2D.Force);
    }

    void BulletRestriksjoner()
    {
        /* Sjekker om skuddet har reist ein viss lengde framover baser på maxRekevidde 
         * vareabelen frå VåpenVariabler skriptet frå det aktive våpenet + start posisjonen til skuddet. 
         * Viss det er sant so sletter skuddet seg sjølv.
         */



        if (spelerGO.transform.position.x > (spawnPositionX + maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (spelerGO.transform.position.y > (spawnPositionY + maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (spelerGO.transform.position.x < (spawnPositionX - maksRekkevidde))
        {
            Destroy(gameObject);
        }
        else if (spelerGO.transform.position.y < (spawnPositionY - maksRekkevidde))
        {
            Destroy(gameObject);
        }

    }

    void FinnSpawnPosisjon()
    {
        spawnPositionX = transform.position.x;
        spawnPositionY = transform.position.y;
    }
}
