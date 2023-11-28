using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenSkript : MonoBehaviour
{
    private Vector3 musPosition;

    public GameObject sjåPåTestGO;
    public GameObject kula;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SjåPåMus();
    }

    void SjåPåMus()
    {
        musPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musPosition.z = 0;
        transform.up = (musPosition - transform.position) * -1;
    }

    void SkytKula()
    {

    }
}
