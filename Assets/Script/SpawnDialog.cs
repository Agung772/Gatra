using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialog : MonoBehaviour
{
    public static SpawnDialog instance;
    public GameObject dialogBoxPrefab;
    public string awal1, awal2, awal3, awal4;
    public string tengahP, tengahE;
    public string akhirP, akhirE;

    private void Start()
    {
        instance = this;

        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(2f);
            SpawnAwal();
        }

    }

    int awalInt;
    public void SpawnAwal()
    {

        awalInt++;
        if (awalInt == 1)
        {
            SpawnDialogs(true, awal1);   
        }
        else if (awalInt == 2)
        {
            SpawnDialogs(false, awal2);
        }
        else if (awalInt == 3)
        {
            SpawnDialogs(true, awal3);
        }
        else if (awalInt == 4)
        {
            SpawnDialogs(false, awal4);
        }

    }

    bool tengahBoolP, tengahBoolE;
    public void SpawnTengah(bool player)
    {
        //GameObject dialogObject = GameObject.FindGameObjectWithTag("Dialog");
        //if (dialogObject != null)
        //{
        //    dialogObject.GetComponent<DialogBox>().Exit();
        //}


        if (player && !tengahBoolP)
        {
            tengahBoolP = true;
            SpawnDialogs(true, tengahP);
        }
        else if (!player && !tengahBoolE)
        {
            tengahBoolE = true;
            SpawnDialogs(false, tengahE);
        }
    }

    bool akhirBoolP, akhirBoolE;
    public void SpawnAkhir(bool player)
    {
        if (player && !akhirBoolP)
        {
            akhirBoolP = true;
            SpawnDialogs(true, akhirP);
        }
        else if (!player && !akhirBoolE)
        {
            akhirBoolE = true;
            SpawnDialogs(false, akhirE);
        }
    }



    public void SpawnDialogs(bool player, string isiText)
    {
        if (player)
        {
            GameObject dialogObject = Instantiate(dialogBoxPrefab, transform);
            dialogObject.GetComponent<DialogBox>().marshall = true;
            dialogObject.GetComponent<DialogBox>().isiString = isiText;

        }
        else if (!player)
        {
            GameObject dialogObject = Instantiate(dialogBoxPrefab, transform);
            dialogObject.GetComponent<DialogBox>().sadin = true;
            dialogObject.GetComponent<DialogBox>().isiString = isiText;
        }

    }
}
