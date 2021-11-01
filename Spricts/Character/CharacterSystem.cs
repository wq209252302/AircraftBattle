using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : IGameSystem
{
    //Dictionary<int, IMonster> monsters ;
    List<IMonster> monsters;
    Player player;
    public CharacterSystem(AircraftBattleGame game):base(game)
    {
        // monsters = new Dictionary<int, IMonster>();
        monsters = new List<IMonster>();
        //MsgCenter.Ins.AddListener("Dead",(obj)=> 
        //{
        //    object[] arr = obj as object[];
        //    IMonster monster = arr[0] as IMonster;
        //    if(monsters.Contains( arr[0] as IMonster))
        //    {
        //       // monsters.Remove(monster);
        //    }
           
        //    GameObjectPool.Ins.InputMonster(monster.GetAttrID(), monster.GetGameobject());
        //});
    }

    public void AddEnemy(IMonster monster)
    {
        // monsters.Add(monster.GetID(),monster);

        monsters.Add(monster);
    }


    public Player GetPlayer()
    {
        return player;
    }

    public override void Init()
    {
        player = new Player();
        player.SetHp(3);
    }

    public override void Release()
    {
       
    }

    public override void Update()
    {
        player.Update();
        foreach (var item in monsters)
        {
            item.Update();
        }
        RemoveDeadEnemy();
    }

    public void RemoveEnemy(IMonster monster)
    {
        monsters.Remove(monster);
    }

    public void RemoveDeadEnemy()
    {
        List<IMonster> list = new List<IMonster>();
        foreach (var item in monsters)
        {
            if(item.isDead)
            {
                list.Add(item);
            }
        }

        for (int i = list.Count-1; i >=0; i--)
        {
            RemoveEnemy(list[i]);
            GameObjectPool.Ins.InputMonster(list[i].GetAttrID(), list[i].GetGameobject());
        }
        list.Clear();
        list = null;
    }
}
