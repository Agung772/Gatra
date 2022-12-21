using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CardSelectManager : MonoBehaviour
{
    public CardSelect[] cardSelect;
    public TextMeshProUGUI text;
    public int totalSelectCard;
    public int codeCard1, codeCard2, codeCard3, codeCard4, codeCard5;

    private void Awake()
    {
        cardSelect = new CardSelect[transform.childCount];
        for (int i = 0; i < cardSelect.Length; i++)
        {
            cardSelect[i] = transform.GetChild(i).GetComponent<CardSelect>();
        }
    }

    public void FinishSelect()
    {
        for (int i = 0; i < cardSelect.Length; i++)
        {
            if (cardSelect[i].select)
            {
                if (codeCard1 == 0)
                {
                    codeCard1 = cardSelect[i].codeCard;
                }
                else if (codeCard2 == 0)
                {
                    codeCard2 = cardSelect[i].codeCard;
                }
                else if (codeCard3 == 0)
                {
                    codeCard3 = cardSelect[i].codeCard;
                }
                else if (codeCard4 == 0)
                {
                    codeCard4 = cardSelect[i].codeCard;
                }
                else if (codeCard5 == 0)
                {
                    codeCard5 = cardSelect[i].codeCard;
                }

            }
        }

        //Check Card
        if (codeCard1 != 0 && codeCard2 != 0 && codeCard3 != 0 && codeCard4 != 0 && codeCard5 != 0)
        {
            PlayerPrefs.SetInt("Card1", codeCard1);
            PlayerPrefs.SetInt("Card2", codeCard2);
            PlayerPrefs.SetInt("Card3", codeCard3);
            PlayerPrefs.SetInt("Card4", codeCard4);
            PlayerPrefs.SetInt("Card5", codeCard5);

            GameManager.instance.LoadGameplay();

        }
        else
        {
            print("Pilih 5 kartu");
            codeCard1 = 0;
            codeCard2 = 0;
            codeCard3 = 0;
            codeCard4 = 0;
            codeCard5 = 0;
        }
    }
    public void PlusTotalSelect()
    {
        if (totalSelectCard < 5)
        {
            totalSelectCard++;
        }
        if (totalSelectCard == 5)
        {
            for (int i = 0; i < cardSelect.Length; i++)
            {
                cardSelect[i].fullCard = true;
            }
        }

        text.text = totalSelectCard + "/5";
    }
    public void MinusTotalSelect()
    {
        if (totalSelectCard > 0)
        {
            totalSelectCard--;

            for (int i = 0; i < cardSelect.Length; i++)
            {
                cardSelect[i].fullCard = false;
            }
        }

        text.text = totalSelectCard + "/5";
    }
}
