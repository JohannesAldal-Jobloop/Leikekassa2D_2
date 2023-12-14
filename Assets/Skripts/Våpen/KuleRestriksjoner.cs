using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KuleRestriksjoner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KuleRestriksjonerFunk(Vector2 opprinnelse, float maksRekkevidde, GameObject kula)
    {
        if (!Physics2D.OverlapCircle(opprinnelse, maksRekkevidde, 10))
        {
            Destroy(kula);
        }
    }

}
