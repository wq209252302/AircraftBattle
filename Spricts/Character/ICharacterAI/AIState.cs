using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState 
{
    protected IMonster m_Character;
    protected float direction = -1;
    public AIState(IMonster character)
    {
        m_Character = character;
    }

    public void SetDirection(float direction )
    {
        this.direction = direction;
    }


    public virtual void Move()
    {
        m_Character.GetGameobject().transform.position+= new Vector3(0,1*direction,0)*Time.deltaTime;
    }


    public void Update()
    {
        Move();
    }
}
;