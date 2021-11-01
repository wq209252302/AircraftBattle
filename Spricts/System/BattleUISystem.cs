using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUISystem : IGameSystem
{
    Dictionary<string, UIBase> dic;
    Transform canvas;
    public BattleUISystem(AircraftBattleGame game) : base(game)
    {
        canvas = GameObject.Find("Canvas").transform;
        dic = new Dictionary<string, UIBase>();
        dic.Add("Charge", new UICharge("Charge", canvas));
        dic.Add("Hp", new UserHp("Hp", canvas));
        dic.Add("Back", new UIBack("Back", canvas));
        dic.Add("Scoreboard", new UIScoreboard("Scoreboard", canvas));

    }

    public override void Init()
    {

    }

    public override void Release()
    {
        dic["Hp"] = null;
        dic["Charge"] = null;
        dic.Clear();
    }

    public override void Update()
    {

    }

    public void UnAttack()
    {
        (dic["Hp"] as UserHp).UnAttack();
    }

    public void ChangValue()
    {
        (dic["Charge"] as UICharge).ChangValue();
    }

    public void ShowBack()
    {
        dic["Back"].Show();
    }

    public void SetData(int num1,int num2)
    {
        (dic["Scoreboard"] as UIScoreboard).SetData(num1,num2);
    }


}
