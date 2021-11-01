using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UICharge : UIBase
{
    int count = 0;
    Slider slider;

    public UICharge(string name, Transform father) : base(name, father)
    {
        slider = m_go.transform.GetComponent<Slider>();
    }


    public void ChangValue()
    {
        count++;
        //Debug.Log(count);
        slider.value = count / 35f;
        if (count >= 35)
        {
            count = 0;
        }
    }
}
