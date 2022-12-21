using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSkillManager : MonoBehaviour
{
    public GameObject[] skillPrefab;
    public int skillCount;
    public GameObject[] skillChield;

    bool[] randomTrue = new bool[6];
    float randomSkill;
    public void Spawn5Skill()
    {
        skillChield = new GameObject[skillPrefab.Length];
        for (int i = 0; i < skillPrefab.Length; i++)
        {
            if (i != 0)
            {
                RandomSkill();
                skillChield[(int)randomSkill] = Instantiate(skillPrefab[(int)randomSkill], transform);
                skillChield[(int)randomSkill].GetComponent<BattleSkill>().skillManager = gameObject.GetComponent<BattleSkillManager>();
            }
        }


    }
    void RandomSkill()
    {
        randomSkill = Random.Range(1, 6);
        if (randomSkill == 1 && !randomTrue[1])
        {
            randomTrue[1] = true;
        }
        else if (randomSkill == 2 && !randomTrue[2])
        {
            randomTrue[2] = true;
        }
        else if (randomSkill == 3 && !randomTrue[3])
        {
            randomTrue[3] = true;
        }
        else if (randomSkill == 4 && !randomTrue[4])
        {
            randomTrue[4] = true;
        }
        else if (randomSkill == 5 && !randomTrue[5])
        {
            randomTrue[5] = true;
        }
        else
        {
            RandomSkill();
        }
    }
    public GameObject[] sisaSkill;
    public void SpawnSkill()
    {
        sisaSkill = new GameObject[transform.childCount];
        for (int i = 0; i < sisaSkill.Length; i++)
        {
            sisaSkill[i] = transform.GetChild(i).gameObject;
            if (sisaSkill[i] != null)
            {
                Destroy(sisaSkill[i]);
            }

        }

        for (int i = 0; i < randomTrue.Length; i++)
        {
            randomTrue[i] = false;
        }
        Spawn5Skill();
    }
}
