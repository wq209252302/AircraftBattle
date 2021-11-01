using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilderSystem : IGameSystem
{

    public EnemyBuilderSystem(AircraftBattleGame game):base(game)
    {
        
    }
    
    public void Construct(EnemyBuilder builder)
    {
        builder.LoadAsset();
        builder.AddWeapon();
        builder.SetEnemyAttr();
        builder.AddAI();
        builder.AddSystem(ABG);



    }
}
