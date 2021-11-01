using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : IGameSystem
{
    public MapSystem(AircraftBattleGame game):base(game)
    {

    }
    int index = 2;
    List<GameObject> maps;
    int count = 1;
    GameObject MapDot;
    float pos = 7.637f;
    float oldpos = 0;

    float moveSpeed = 2f;
    public override void Init()
    {
        maps = new List<GameObject>();
        MapDot = GameObject.Find("Map");
        for (int i = 0; i < MapDot.transform.childCount; i++)
        {
            maps.Add(MapDot.transform.GetChild(i).gameObject);
        }
    }

    public override void Release()
    {
        for (int i = maps.Count-1; i >= 0; i++)
        {
            GameObject.Destroy(maps[i]);
        }
        maps.Clear();
    }

    public override void Update()
    {
        MapDot.transform.Translate(new Vector3(0, -1*moveSpeed, 0) * Time.deltaTime);
        if ((Mathf.Abs(MapDot.transform.position.y) -Mathf.Abs(oldpos)) > pos)
        {
            oldpos = MapDot.transform.position.y;
            maps[index].transform.localPosition += new Vector3(0, pos*count*3, 0);

            //Debug.Log(maps[index].transform.name);

            index--;
            if (index < 0)
            {
                index = 2;
                //count++;
            }
        }
    }


    public void SetMovwSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
