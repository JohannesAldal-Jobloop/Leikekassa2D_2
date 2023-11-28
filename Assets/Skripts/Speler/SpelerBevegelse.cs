using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerBevegelse : MonoBehaviour
{
    private float vertikalInput;
    private float horisontalInput;

    public float gåFart;
    public float hoppKraft;

    public bool toppNedBevegelse;

    private Rigidbody2D spelerRB;

    // Start is called before the first frame update
    void Start()
    {
        spelerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toppNedBevegelse)
        {
            spelerRB.gravityScale = 0;
            BevegelseWASDTop();
        }
        else
        {
            spelerRB.gravityScale = 1;
            BevegelseWASDSida();
            HoppSida();
        }
        
    }

    void BevegelseWASDSida()
    {
        vertikalInput = Input.GetAxis("Vertical");
        horisontalInput = Input.GetAxis("Horizontal");

        float vertikalBevegelse = vertikalInput * Time.deltaTime;
        float horisontaBevegelse = horisontalInput * Time.deltaTime * gåFart;

        spelerRB.AddForce(Vector2.right * horisontaBevegelse);
    }

    void BevegelseWASDTop()
    {
        vertikalInput = Input.GetAxis("Vertical");
        horisontalInput = Input.GetAxis("Horizontal");

        float vertikalBevegelse = vertikalInput * Time.deltaTime * gåFart;
        float horisontaBevegelse = horisontalInput * Time.deltaTime * gåFart;

        spelerRB.AddForce(Vector2.right * horisontaBevegelse);
        spelerRB.AddForce(Vector2.up * vertikalBevegelse);
    }

    void HoppSida()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spelerRB.AddForce(Vector2.up * Time.deltaTime * hoppKraft);
        }
        
    }

    void HoppTop()
    {

    }

}
