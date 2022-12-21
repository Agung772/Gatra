using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardSelect : MonoBehaviour
{
    public int codeCard;
    public CardSelectManager cardSelectManager;
    public bool select, fullCard;
    public RectTransform rectTransform;
    private void Start()
    {
        cardSelectManager = GetComponentInParent<CardSelectManager>();
        rectTransform = GetComponent<RectTransform>();
    }
    public void Select()
    {
        if (!fullCard)
        {
            if (!select)
            {
                select = true;

                rectTransform.sizeDelta = new Vector2(350f * 1.2f, 550f * 1.2f);
                cardSelectManager.PlusTotalSelect();
            }
            else if (select)
            {
                select = false;
                rectTransform.sizeDelta = new Vector2(350f, 550f);
                cardSelectManager.MinusTotalSelect();
            }
        }
        else
        {
            print("Deck Penuh");
            if (select)
            {
                select = false;
                rectTransform.sizeDelta = new Vector2(350f, 550f);
                cardSelectManager.MinusTotalSelect();
            }
        }

    }
}
