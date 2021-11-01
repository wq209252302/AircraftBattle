using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private EnemyBuilderSystem m_BuilderDirector = new EnemyBuilderSystem(AircraftBattleGame.Ins);
    public override IMonster CreatMonster(ENUM_MONSTER MonsterType, WEAPON_ENUM weapon, Vector3 pos, Vector3 pos_2)
    {
        EnemyBuilderParam param = new EnemyBuilderParam();
        switch (MonsterType)
        {
            case ENUM_MONSTER.type1:
                param.monster = new Dogface();
                param.m_aIstate = new AIAdvance(param.monster);
                param.Spawn = pos;
                param.AttrID = 1;
                break;
            case ENUM_MONSTER.type2:
                param.monster = new Soldier();
                param.m_aIstate = new AIincline(param.monster, Random.Range(-1, 1));
                if ((param.m_aIstate as AIincline).Getfront() >= 0)
                {
                    (param.m_aIstate as AIincline).Setfront(1);
                    param.Spawn = pos;
                }
                else
                {

                    param.Spawn = pos_2;
                }
                param.AttrID = 2;
                break;
            case ENUM_MONSTER.type3:
                break;
            default:
                break;
        }

        if (param == null)
        {
            return null;
        }
        param.emWeapon = weapon;


        EnemyBuilder enemyBuilder = new EnemyBuilder();
        enemyBuilder.SetBuildParm(param);

        m_BuilderDirector.Construct(enemyBuilder);
        return param.monster;

    }
}
