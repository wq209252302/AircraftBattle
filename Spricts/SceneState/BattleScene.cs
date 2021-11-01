using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : StateBase
{
    public BattleScene(SceneStageCtrl ctrl) : base(ctrl)
    {
        Name = "BattleScene";
    }

    public override void StartBegin()
    {
        AircraftBattleGame.Ins.Init(this);
    }

    public override void StartEnd()
    {
        AircraftBattleGame.Ins.Release();
        //AircraftBattleGame.Ins = null;
    }

    public override void Update()
    {
        AircraftBattleGame.Ins.Update();
    }

    public void ToScene()
    {
        ctrl.SetState(new StartScene(ctrl),"InitScene");
    }
}
