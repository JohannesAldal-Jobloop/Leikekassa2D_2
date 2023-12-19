using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolgGO : MonoBehaviour
{
    public GameObject malGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FolgGOFunk();
    }

    void FolgGOFunk()
    {
        gameObject.transform.position = new Vector3(malGO.transform.position.x, malGO.transform.position.y, -10);
    }
}
