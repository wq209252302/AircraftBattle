using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : IBuilder
{
    private static Dictionary<int, AttrBase> m_EnemyAttrDB = new Dictionary<int, AttrBase>();
    static int id = 0;
    private EnemyBuilderParam m_builderParam = null;

    public override void AddAI()
    {
        ICharacterAI characterAI = new ICharacterAI(m_builderParam.monster);
        characterAI.ChangeAIState(m_builderParam.m_aIstate);
        m_builderParam.monster.SetCharacterAI(characterAI);
    }
    public override void AddWeapon()
    {
        IWeapon weapon;
        GameObject bullet = null;
        switch (m_builderParam.emWeapon)
        {

            case WEAPON_ENUM.type1:
                weapon = new Level1(0);
                bullet = Resources.Load<GameObject>("bullet3");
                weapon.SetWeaponPos(m_builderParam.monster.GetGameobject().transform.Find("Frie1").gameObject);
                break;
            case WEAPON_ENUM.type2:
                weapon = new Level2(1);
                bullet = Resources.Load<GameObject>("bullet3");
                weapon.SetWeaponPos(m_builderParam.monster.GetGameobject().transform.Find("Frie1").gameObject);
                break;
            case WEAPON_ENUM.type3:
                weapon = new Level3();
                bullet = Resources.Load<GameObject>("bullet3");
                weapon.SetWeaponPos(m_builderParam.monster.GetGameobject().transform.Find("Frie1").gameObject);
                break;
            default:
                weapon = new Level1(0);
                bullet = Resources.Load<GameObject>("bullet3");
                weapon.SetWeaponPos(m_builderParam.monster.GetGameobject().transform.Find("Frie1").gameObject);
                break;
        }
        weapon.SetBullet(bullet);

        m_builderParam.monster.SetWeapon(weapon);
    }

    public override void LoadAsset()
    {
        GameObject obj = GameObjectPool.Ins.MonsteOutrPut(m_builderParam.AttrID );
        GameObject boom;
        if (obj == null)
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>((m_builderParam.AttrID ).ToString()));
            obj.AddComponent<CrashTool>().Init(m_builderParam.monster);
            boom = GameObject.Instantiate(Resources.Load<GameObject>("Boom"));
            boom.name = "Boom";
            boom.transform.SetParent(obj.transform);          
        }
        
        boom = obj.transform.Find("Boom").gameObject;
        boom.transform.position = Vector3.zero;
        obj.GetComponent<CrashTool>().Init(m_builderParam.monster);
        switch (m_builderParam.AttrID)
        {
            case 1:
                obj.transform.position = new Vector3(Random.Range(-2f, 2f), m_builderParam.Spawn.y, Random.Range(-2f, 2f));
                break;
            case 2:
                obj.transform.position = new Vector3(m_builderParam.Spawn.x, m_builderParam.Spawn.y,0);
                break;
            case 3:
                break;
            default:
                break;
        }
      
        m_builderParam.monster.SetGameObject(obj);

    }

    public override void SetEnemyAttr()
    {
        if (!m_EnemyAttrDB.ContainsKey(m_builderParam.AttrID))
        {
            m_EnemyAttrDB.Add(m_builderParam.AttrID, new AttrBase(1, (m_builderParam.AttrID) *3 /2, 1));

        }
        m_builderParam.monster.SetAttr(new EnemyAttr(m_EnemyAttrDB[m_builderParam.AttrID], id, m_builderParam.monster));
        m_builderParam.monster.GetGameobject().name = id.ToString();
        id++;


    }

    public override void SetBuildParm(EnemyBuilderParam param)
    {
        m_builderParam = param;

    }



    public override void AddSystem(AircraftBattleGame game)
    {
        game.AddEnemy(m_builderParam.monster);
    }
}
