using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_MONSTER
{
    type1,
    type2,
    type3
}
public class IMonster
{
    protected AttrBase m_attr;
    protected GameObject m_go;
    protected ICharacterAI characterAI;
    protected ENUM_MONSTER monsterType;
    protected IWeapon weapon;
    protected int AttrID;
    protected string m_AssetName = "";
    public bool isDead = false;
    public bool IsDele = true;
    protected Animator anim;
    protected GameObject Boom;

    public int GetID()
    {
        return (m_attr as EnemyAttr).Id;
    }
    public int GetAttrID()
    {
        return AttrID;
    }

    public void SetWeapon(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    public IWeapon GetWeapon()
    {
        return weapon;
    }

    public GameObject GetGameobject()
    {
        return m_go;
    }


    public void SetGameObject(GameObject obj)
    {
        m_go = obj;
        Boom = obj.transform.Find("Boom").gameObject;
        anim = Boom.GetComponent<Animator>();

    }

    public void SetAttr(AttrBase attr)
    {
        m_attr = attr;

    }

    public AttrBase GetAttr()
    {
        return m_attr;
    }


    public void SetCharacterAI(ICharacterAI characterAI)
    {
        this.characterAI = characterAI;
    }

    public virtual void Release()
    {

    }

    public virtual void Update()
    {
        if (!isDead)
        {

            characterAI.Update();
            weapon.Update();
        }
        if(m_go.transform.position.y<=-6)
        {
            Dead();
        }

    }

    public void UnAttack()
    {
        if(IsDele)
        {
            (m_attr as EnemyAttr).UnAttack();
        }

    }

    public virtual void Dead()
    {
        if(IsDele)
        {
            anim.Play("Boom");
            MsgCenter.Ins.SendMsg("EnemyDead",m_attr.MaxHp);
            weapon.Dead();
            isDead = true;
            m_go.transform.position += new Vector3(20, 0, 0);
            Boom.transform.position = m_go.transform.position-new Vector3(20,0,0) ; 
            // MsgCenter.Ins.SendMsg("Dead",this);
            m_attr = null;
            characterAI = null;
            weapon = null;
            IsDele = false;
        }


    }
}
