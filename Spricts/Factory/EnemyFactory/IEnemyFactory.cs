using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemyFactory 
{
    public abstract IMonster CreatMonster(ENUM_MONSTER MonsterType, WEAPON_ENUM weapon,Vector3 pos, Vector3 pos_2);
}
