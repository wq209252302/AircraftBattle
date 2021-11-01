using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : IMonster
{
    float time = 0.3f;
    public Soldier()
    {
        monsterType = ENUM_MONSTER.type2;
        AttrID = 2;
        m_AssetName = "2";
        

    }

    public override void Update()
    {
        if (!isDead)
        {

            characterAI.Update();
            weapon.Update();
            
        }
        if (m_go.transform.position.y <= -6||Mathf.Abs(m_go.transform.position.x)>5f)
        {
            Dead();
        }
        if (weapon != null && Time.time - time > 1.0F)
        {
            time = Time.time;
            weapon.Frie();
        }

        //if (weapon != null )
        //{

        //    weapon.Frie();
        //}
    }


}
