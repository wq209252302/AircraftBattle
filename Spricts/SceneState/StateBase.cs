using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
 protected  SceneStageCtrl ctrl;

    private string name = "SceneState";

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public StateBase(SceneStageCtrl ctrl)
    {
        this.ctrl = ctrl;
    }
    public virtual void StartBegin()
    {

    }
    public virtual void StartEnd()
    {

    }

    public virtual void Update()
    {

    }
}
