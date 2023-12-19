using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarSkade2D : MonoBehaviour
{


    /* Lag ein liste som inneholder GameObjects med colliders.
     * Dette blir hitboksene til det GameObjectet som dett skripte er koble til.
     */

    /* For at dette skripte skal virke:
     * Collider.
     */

    public float maksLiv = 10;
    public float liv = 10;

    public bool erDød = false;

    // public GameObject gameOverScreen;

    public List<Collider2D> taSkadeCollidersList = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        liv = maksLiv;

    }

    // Update is called once per frame
    void Update()
    {
        SkjekkOmHarLiv();
    }

    public void TaSkade(float skade)
    {
        liv -= skade;
    }

    void SlettSegSjølv()
    {
        Destroy(gameObject);
    }

    void SkjekkOmHarLiv()
    {
        if (liv <= 0)
        {
            erDød = true;

            if (gameObject.layer == 3)
            {
                Time.timeScale = 0;
            }
            else
            {
                SlettSegSjølv();
            }

        }
        else
        {
            erDød = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
