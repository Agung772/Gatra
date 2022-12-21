using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotController : MonoBehaviour
{
    public GameObject cardPlayer, cardEnemy;
    public ParticleSystem semburanNaga;
    public float berapaSemburan;
    public string element;
    public int codeElement;
    public TextMeshProUGUI elementText;
    public GameObject elementUI;
    public GameObject[] elementLogo;
    private void Awake()
    {
        elementText.text = "";

        elementLogo = new GameObject[elementUI.transform.childCount];
        for (int i = 0; i < elementUI.transform.childCount; i++)
        {
            elementLogo[i] = elementUI.transform.GetChild(i).gameObject;
        }
    }
    private void Start()
    {


    }
    public void RandomElement()
    {
        ResetLogo();
        float random = Random.Range(1, 5);
        if (random == 1)
        {
            element = "Api";
            codeElement = 1;
            elementLogo[codeElement].SetActive(true);
        }
        else if (random == 2)
        {
            element = "Air";
            codeElement = 2;
            elementLogo[codeElement].SetActive(true);
        }
        else if (random == 3)
        {
            element = "Tanah";
            codeElement = 3;
            elementLogo[codeElement].SetActive(true);
        }
        else if (random == 4)
        {
            element = "Udara";
            codeElement = 4;
            elementLogo[codeElement].SetActive(true);
        }
        elementText.text = element;

        //Particle
        StartCoroutine(Particle());
        IEnumerator Particle()
        {
            semburanNaga.Play();
            yield return new WaitForSeconds(berapaSemburan);
            semburanNaga.Play();

        }
    }

    void ResetLogo()
    {
        for (int i = 0; i < elementLogo.Length; i++)
        {
            if (i != 0)
            {
                elementLogo[i].SetActive(false);
            }
        }
    }
}
