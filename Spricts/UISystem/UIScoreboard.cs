using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScoreboard : UIBase
{
    //Scoreboard
    Text killnum;
    Text score;
    public UIScoreboard(string name, Transform father) : base(name, father)
    {
        killnum = m_go.transform.Find("KillNum").GetComponent<Text>();
        score = m_go.transform.Find("Score").GetComponent<Text>();

    }


    public void SetData(int num1,int num2)
    {
        killnum.text = num2.ToString();
        score.text = num1.ToString();

    }
}
