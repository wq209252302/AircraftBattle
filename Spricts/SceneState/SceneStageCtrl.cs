using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStageCtrl 
{
    private StateBase m_State;
    private bool IsRunBagin = false;
    private AsyncOperation async;

    public void SetState(StateBase state,string name)
    {
        IsRunBagin = false;

        LoadCsene(name);
        if(m_State!=null)
        {
            m_State.StartEnd();
        }
        m_State = state;
    }


    private void LoadCsene(string name)
    {
        if(name.Length==0||name==null)
        {
            return;
        }
        async = SceneManager.LoadSceneAsync(name);
    }

    public void Update()
    {
        if(async!=null&&!async.isDone)
        {
            return;
        }

        if(m_State!=null&&IsRunBagin==false)
        {
            m_State.StartBegin();
            IsRunBagin = true;
        }

        if (m_State != null)
        {
            m_State.Update();
        }


    }


}
