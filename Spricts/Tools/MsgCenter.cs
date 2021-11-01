using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MsgCenter 
{
    private static MsgCenter ins;
    public static MsgCenter Ins
    {
        get
        {
            if(ins==null)
            {
                ins = new MsgCenter();
            }
            return ins;
        }
    }

    Dictionary<string, Action<object[]>> m_MsgDicts = new Dictionary<string, Action<object[]>>();

    public void AddListener(string msg,Action<object[]> action)
    {
        if(!m_MsgDicts.ContainsKey(msg))
        {
            m_MsgDicts.Add(msg,null);
        }
        m_MsgDicts[msg] += action;
    }

    public void RemoveListener(string msg,Action<object[]> action)
    {
        if(m_MsgDicts.ContainsKey(msg))
        {
            m_MsgDicts[msg] -= action;
            if(m_MsgDicts[msg] == null)
            {
                m_MsgDicts.Remove(msg);
            }
        }
    }

    public void SendMsg(string msg,params object [] arr)
    {
        if(m_MsgDicts.ContainsKey(msg))
        {
            m_MsgDicts[msg].Invoke(arr);
        }
    }
}
