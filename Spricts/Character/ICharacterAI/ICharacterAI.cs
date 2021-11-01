using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAI
{
    protected IMonster m_Character;
    protected AIState m_ai = null;

    public ICharacterAI(IMonster character)
    {
        m_Character = character;
    }

    public virtual void ChangeAIState(AIState aI)
    {
        m_ai = aI;
    }

    public void Update()
    {
        m_ai.Update();
       
    }

}
