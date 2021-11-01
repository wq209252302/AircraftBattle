using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIBack : UIBase
{
    Button button;
    public UIBack(string name, Transform father) : base(name, father)
    {

        button = m_go.transform.Find("Back").GetComponent<Button>();
        button.onClick.AddListener(()=> 
        {
            AircraftBattleGame.Ins.ToScene();
        });
        Close();
    }


}