using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBullet
{
    public GameObject m_go;
    public bool isHead;
    public IBullet()
    {
        isHead = false;
    }

    public void SetGameObject(GameObject game)
    {
        m_go = game;
    }


    public void Dead()
    {
        isHead = true;
        m_go.transform.position += new Vector3(40, 0, 0);
        GameObject.Destroy(m_go.GetComponent<DistanceTools>());
    }
    public abstract void Result();
}
