using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelerBevegelse : MonoBehaviour
{
    private float vertikalInput;
    private float horisontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BevegelseWASD()
    {
        horisontalInput = Input.GetAxis("Horizontal");
        vertikalInput = Input.GetAxis("Vertical");
    }
}
