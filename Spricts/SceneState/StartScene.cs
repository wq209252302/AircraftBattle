using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : StateBase
{
    float time = 0;
    public StartScene(SceneStageCtrl ctrl) : base(ctrl)
    {
        Name = "InitScene";
    }

    public override void StartBegin()
    {

    }

    public override void StartEnd()
    {

    }

    public override void Update()
    {

        ctrl.SetState(new BattleScene(ctrl), "BattleScene");


    }
}
