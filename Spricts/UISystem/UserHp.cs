using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHp : UIBase
{
    int count = 0;
    public UserHp(string name,Transform father):base(name, father)
    {

    }


    public void UnAttack()
    {
        if(count>2)
        {
            count = 2;
        }
       // Debug.Log(count);
        m_go.transform.GetChild(count).gameObject.SetActive(false);
        count++;
    }


}
