using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilderParam
{
    public WEAPON_ENUM emWeapon = WEAPON_ENUM.Null;
    public IMonster monster = null;
    public Vector3 Spawn;
    public int AttrID;
    public AIState m_aIstate;

    
}

public abstract class IBuilder
{
    public abstract void SetBuildParm(EnemyBuilderParam param);

    public abstract void LoadAsset();
    public abstract void AddWeapon();
    public abstract void AddAI();

    public abstract void SetEnemyAttr();

    public abstract void AddSystem(AircraftBattleGame game);

}
