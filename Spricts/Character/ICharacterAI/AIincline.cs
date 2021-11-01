using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIincline : AIState
{
    int front;
    public AIincline(IMonster monster,int front) : base(monster)
    {
        this.front = front;
    }

    public int Getfront()
    {
        return front;
    }

    public void  Setfront( int  num)
    {
       front = num;
    }

    public override void Move()
    {
        //base.Move();
        m_Character.GetGameobject().transform.position += new Vector3(1.8f*front, 1 * direction, 0) * Time.deltaTime;
    }

}
