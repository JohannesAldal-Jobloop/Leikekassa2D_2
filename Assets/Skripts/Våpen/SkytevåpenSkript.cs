using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenSkript : MonoBehaviour
{
    private Vector3 musPosition;

    public GameObject sjåPåTestGO;

    public GameObject aktivtSiktepunkt;
    public GameObject aktivtVåpen;
    public GameObject aktivtKuleSpawnpunkt;

    public List<GameObject> kuleList = new List<GameObject>();
    public List<GameObject> våpenList = new List<GameObject>();
    public List<GameObject> siktepunktList = new List<GameObject>();
    public List<GameObject> kuleSpawnpunktList = new List<GameObject>();

    public VåpenVariabler aktivVåpenVariabler;

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

    void FinnAktivtVåpen()
    {
        for (int i = 0; i < våpenList.Count; i++)
        {
            if (våpenList[i].activeSelf == true)
            {
                aktivtVåpen = våpenList[i];
            }
        }
    }

    void SpawnKula()
    {
        KuleSkript clone = Instantiate(aktivVåpenVariabler.kulaSkript[aktivVåpenVariabler.kulaBrukt], aktivtKuleSpawnpunkt.transform);

        clone.skade = aktivVåpenVariabler.skade;
        clone.fart = aktivVåpenVariabler.kuleFart;
        clone.tilbakeslagKraft = aktivVåpenVariabler.tilbakeslagKraft;
        clone.maksRekkevidde = aktivVåpenVariabler.maksRekkevidde;
        clone.skyteModus = aktivVåpenVariabler.skyteModus;

        aktivVåpenVariabler.magasinMengdeNo--;

    }
}
