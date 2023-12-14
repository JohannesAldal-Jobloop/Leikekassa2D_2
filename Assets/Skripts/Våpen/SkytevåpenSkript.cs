using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkytevåpenSkript : MonoBehaviour
{
    private float nesteTidSkyte = 0;

    public bool prosjektilSkyting = true;
    private bool reloader = false;

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
        FinnAlleAktiveGameobjectForScript();
    }

    // Update is called once per frame
    void Update()
    {
        SjåPåMus();

        //if (!spelerDødSkript.respawner)
        //{
            if (aktivVåpenVariabler.skyteModus == 1 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
            {
                FullAutoSkyting();
            }
            else if (aktivVåpenVariabler.skyteModus == 2 && aktivVåpenVariabler.magasinMengdeNo != 0 && !reloader)
            {
                SemiAutoSkyting();
            }

            if (Input.GetKey(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        //}
    }

    void SjåPåMus()
    {
        musPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musPosition.z = 0;
        transform.up = (musPosition - transform.position) * -1;
    }

    void FinnAlleAktiveGameobjectForScript()
    {
        FinnAktivtVåpen();
        FinnAktivVåpenVariabler();
        FinnAktivKulespawnpunkt();
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

    void FinnAktivKulespawnpunkt()
    {
        for (int i = 0; i < kuleSpawnpunktList.Count; i++)
        {
            if (kuleSpawnpunktList[i].activeInHierarchy == true)
            {
                aktivtKuleSpawnpunkt = kuleSpawnpunktList[i];
            }
        }
    }

    void FinnAktivVåpenVariabler()
    {
        aktivVåpenVariabler = aktivtVåpen.GetComponent<VåpenVariabler>();
    }

    void SpawnKula()
    {
        KuleSkript2D clone = Instantiate(aktivVåpenVariabler.kulaSkript[aktivVåpenVariabler.kulaBrukt], aktivtKuleSpawnpunkt.transform);

        clone.skade = aktivVåpenVariabler.skade;
        clone.fart = aktivVåpenVariabler.kuleFart;
        clone.maksRekkevidde = aktivVåpenVariabler.maksRekkevidde;

        aktivVåpenVariabler.magasinMengdeNo--;

    }

    IEnumerator Reload()
    {
        reloader = true;
        yield return new WaitForSeconds(aktivVåpenVariabler.reloadFart);
        aktivVåpenVariabler.magasinMengdeNo = aktivVåpenVariabler.magasinKapasitet;
        reloader = false;
    }

    public void FullAutoSkyting()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nesteTidSkyte)
        {
            nesteTidSkyte = Time.time + 1f / aktivVåpenVariabler.angrepHastigheit;
            if (prosjektilSkyting)
            {
                SpawnKula();
            }

        }
    }

    public void SemiAutoSkyting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nesteTidSkyte)
        {
            nesteTidSkyte = Time.time + 1f / aktivVåpenVariabler.angrepHastigheit;
            if (prosjektilSkyting)
            {
                SpawnKula();
            }
        }

    }
}
