using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrBase 
{
    public float FlySpeed ;
    public int MaxHp;
    public int Attack;


    public AttrBase(float speed,int hp,int atk)
    {
        FlySpeed = speed;
        MaxHp = hp;
        Attack = atk;
    }

   
}

