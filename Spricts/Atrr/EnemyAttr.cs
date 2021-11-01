using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : AttrBase
{
    IMonster monster;
    public EnemyAttr(float speed, int hp, int atk, int id, IMonster monster) : base(speed, hp, atk)
    {
        Hp = hp;
        Id = id;
        this.monster = monster;
    }

    public EnemyAttr(AttrBase attr, int id, IMonster monster) : base(attr.FlySpeed, attr.MaxHp, attr.Attack)
    {
        Hp = attr.MaxHp;
        Id = id;
        this.monster = monster;
    }

    int Hp;
    public int Id;

    public void UnAttack()
    {
        Hp -= 1;
        if(Hp<=0)
        {
            monster.Dead();
        }
    }

}
