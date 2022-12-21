using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSkill : MonoBehaviour
{
    public int efekSkill;
    public BattleSkillManager skillManager;

    public void SkillPlayer(int parameter)
    {
        BattleManager.instance.AttackPlayer(parameter);
        skillManager.SpawnSkill();
        Destroy(gameObject);

        AudioManager.instance.ButtonUISfx();
    }
    public void SkillEnmey()
    {
        skillManager.SpawnSkill();
        BattleManager.instance.AttackEnemy(efekSkill);
        Destroy(gameObject);
        print("Enmey pake skill " + efekSkill);
    }
}
