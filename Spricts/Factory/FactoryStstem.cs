using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryStstem : IGameSystem
{
    GameObject pos1;
    GameObject pos2; 
    GameObject pos3;

    public FactoryStstem(AircraftBattleGame game) : base(game)
    {
        pos1 = GameObject.Find("Dot1");
        pos2 = GameObject.Find("Dot2");
        pos3 = GameObject.Find("Dot3");
    }

    public static EnemyFactory enemyFactory = new EnemyFactory();
    public static BulletFactory bulletFactory = new BulletFactory();

    public void CreatEnemy_1(ENUM_MONSTER type1, WEAPON_ENUM weapon)
    {
        enemyFactory.CreatMonster(type1, weapon, pos1.transform.position,Vector3.zero);
    }

    public void CreatEnemy_2(ENUM_MONSTER type1, WEAPON_ENUM weapon)
    {
        enemyFactory.CreatMonster(type1, weapon, pos2.transform.position, pos3.transform.position);
    }
    public void CreatBullet(int id)
    {
        bulletFactory.CreatFactory(id);
    }


    public override void Init()
    {

    }



    public override void Release()
    {

    }

    public override void Update()
    {

    }
}
