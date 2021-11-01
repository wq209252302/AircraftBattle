using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftBattleGame 

{ 
    private static AircraftBattleGame ins;
    public static AircraftBattleGame Ins
    {
        get 

        {
            if(ins ==null)
            {
                ins = new AircraftBattleGame();
            }
            return ins;
        }
    }
    BattleScene battleScene;

    MapSystem map;
    FactoryStstem factory;
    CharacterSystem character;
    InputSystem inputSystem;
    BattleUISystem uISystem;

    float time = 0;
    public void Init(BattleScene battleScene)
    {
        Time.timeScale = 1;
        this.battleScene = battleScene;
        map = new MapSystem(this);
        map.Init();
        factory = new FactoryStstem(this);
        factory.Init();
        character = new CharacterSystem(this);
        character.Init();
        inputSystem = new InputSystem(this);
        inputSystem.Init();
        inputSystem.SetPlayer(character.GetPlayer());
        uISystem = new BattleUISystem(this);
        uISystem.Init();
       // factory.CreatEnemy(ENUM_MONSTER.type1, WEAPON_ENUM.type1);

    }

    public void Release()
    {
        uISystem.Release();
        uISystem = null;
    }

    public void Update()
    {
        map.Update();
        factory.Update();
        character.Update();
        inputSystem.Update();
        if (Time.time-time>1.3f)
        {
            time = Time.time;
            factory.CreatEnemy_1(ENUM_MONSTER.type1,WEAPON_ENUM.type1);
            factory.CreatEnemy_2(ENUM_MONSTER.type2, WEAPON_ENUM.type1);
        }

    }

    public void AddEnemy(IMonster monster)
    {
        if(character!=null)
        {
            character.AddEnemy(monster);
        }
    }


    public Player GetPlayer()
    {
        return character.GetPlayer();
    }


    public void UnAttack()
    {
        uISystem.UnAttack();
    }

    public void ChangValue()
    {
        uISystem.ChangValue();
    }


    public void UIBackShow()
    {
        uISystem.ShowBack();
    }

    public void ToScene()
    {
        battleScene.ToScene();
    }

    public void SetData(int num1, int num2)
    {
        uISystem.SetData(num1, num2);
    }
}
