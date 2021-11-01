using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase
{
    protected GameObject m_go;
    public UIBase(string name, Transform father)
    {
        m_go = GameObject.Instantiate(Resources.Load<GameObject>(name), father, false);
        m_go.name = name;
        Init();
    }

    public virtual void Init() { }

    public virtual void Show()
    {
        m_go.SetActive(true);
    }
    public virtual void Close()
    {
        m_go.SetActive(false);
    }


    public virtual void Update()
    {

    }
    //public

}
