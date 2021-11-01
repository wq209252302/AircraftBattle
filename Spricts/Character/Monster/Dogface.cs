using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogface : IMonster
{
    float time = 0.3f;
    public Dogface()
    {
        monsterType = ENUM_MONSTER.type1;
        AttrID = 1;
        m_AssetName = "1";

    }

    public override void Update()
    {
        base.Update();
        if (weapon != null && Time.time - time > 1.3F)
        {
            time = Time.time;

            weapon.Frie();
        }


        //if (weapon != null)
        //{

        //    weapon.Frie();
        //}
    }




}
