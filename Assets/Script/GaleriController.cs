using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaleriController : MonoBehaviour
{
    public GameObject[] textDesk;

    public void SelectCardGaleri(int card)
    {
        if (card == 1)
        {
            ResetTextCard();
            textDesk[1].SetActive(true);
        }
        else if (card == 2)
        {
            ResetTextCard();
            textDesk[2].SetActive(true);
        }
        else if (card == 3)
        {
            ResetTextCard();
            textDesk[3].SetActive(true);
        }
        else if (card == 4)
        {
            ResetTextCard();
            textDesk[4].SetActive(true);
        }
        else if (card == 5)
        {
            ResetTextCard();
            textDesk[5].SetActive(true);
        }
        else if (card == 6)
        {
            ResetTextCard();
            textDesk[6].SetActive(true);
        }
        else if (card == 7)
        {
            ResetTextCard();
            textDesk[7].SetActive(true);
        }
        else if (card == 8)
        {
            ResetTextCard();
            textDesk[8].SetActive(true);
        }
        else if (card == 9)
        {
            ResetTextCard();
            textDesk[9].SetActive(true);

        }
        else if (card == 10)
        {
            ResetTextCard();
            textDesk[10].SetActive(true);
        }
        else if (card == 11)
        {
            ResetTextCard();
            textDesk[11].SetActive(true);
        }
        else if (card == 12)
        {
            ResetTextCard();
            textDesk[12].SetActive(true);
        }

        AudioManager.instance.ButtonUISfx();
    }


    void ResetTextCard()
    {
        for (int i = 0; i < textDesk.Length; i++)
        {
            if (i != 0)
            {
                textDesk[i].SetActive(false);
            }

        }
    }
}
