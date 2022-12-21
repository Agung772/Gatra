using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCardMainMenu : MonoBehaviour
{
    public GameObject cardMainmenuPrefab;
    public float min, max;
    private void Start()
    {
        InvokeRepeating("SpawnsCard", 0, 0.5f);
    }

    void SpawnsCard()
    {
        Instantiate(cardMainmenuPrefab, this.transform.position + new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max + 10)), this.transform.rotation);
    }
}
