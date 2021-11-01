using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
    private static GameObjectPool ins;
    public static Dictionary<int, Queue<GameObject>> Monsters = new Dictionary<int, Queue<GameObject>>();
    public static Dictionary<int, Queue<GameObject>> Bullets = new Dictionary<int, Queue<GameObject>>();
    public static GameObjectPool Ins
    {
        get
        {
            if (ins == null)
            {
                ins = new GameObjectPool();
                Monsters.Add(0, new Queue<GameObject>());
                Monsters.Add(1, new Queue<GameObject>());
                Monsters.Add(2, new Queue<GameObject>());
                Bullets.Add(0, new Queue<GameObject>());
                Bullets.Add(1, new Queue<GameObject>());
                Bullets.Add(2, new Queue<GameObject>());
            }
            return ins;
        }
    }


    public void InputMonster(int id, GameObject obj)
    {
        Monsters[id].Enqueue(obj);

    }

    public GameObject MonsteOutrPut(int id)
    {
        if (Monsters[id].Count > 0)
        {
            //Debug.Log(id + "取出去一个");
            return Monsters[id].Dequeue();
        }

        return null;
    }


    public void InputBullets(int id, GameObject obj)
    {

        Bullets[id].Enqueue(obj);
    }

    public GameObject BulletsOutrPut(int id)
    {
        if (Bullets[id].Count > 0)
        {
            return Bullets[id].Dequeue();
        }

        return null;
    }



}
