using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameSystem 
{
    protected AircraftBattleGame ABG;
    public IGameSystem (AircraftBattleGame game)
    {
        ABG = game;
    }
    public virtual void Init()
    {

    }

    public virtual void Release()
    {

    }


    public virtual void Update()
    {

    }
}
