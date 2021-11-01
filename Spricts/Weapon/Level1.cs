using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : IWeapon
{   

    public Level1 (int id)
    {
        WeaponType = WEAPON_ENUM.type1;
        this.Id = id;
       // bullet = Resources.Load<GameObject>("bullet1");
    }

    public override void reload()
    {
        UsualBullet usual = new UsualBullet();
        GameObject bullet = GameObjectPool.Ins.BulletsOutrPut(Id);
        if (bullet==null)
        {
            bullet = CreatBullet();
        }
        usual.SetGameObject(bullet);
        if(usual.m_go.GetComponent<DistanceTools>()==null)
        {
            usual.m_go.AddComponent<DistanceTools>().Init(usual, AircraftBattleGame.Ins.GetPlayer().GetGameObject().transform);
        }
        usual.m_go.GetComponent<DistanceTools>().enabled = true;
        usual.m_go.GetComponent<DistanceTools>().flag = true;
        bullet.transform.position = WeaponPos.transform.position;

        bullets.Add(usual);

    }

    public override void BulletsUpdate()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].isHead)
            {
                bullets[i].m_go.transform.Translate(new Vector3(0, 4 * direction, 0) * Time.deltaTime);
                if (bullets[i].m_go.transform.position.y < -6)
                {
                    bullets[i].isHead = true;
                }
            }

        }
    }

    public override void DelBullet()
    {
        List<IBullet> list = new List<IBullet>();
        foreach (var item in bullets)
        {
            if (item.isHead)
            {
                list.Add(item);
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            bullets.Remove(list[i]);
            list[i].Dead();
            GameObjectPool.Ins.InputBullets(Id, list[i].m_go);
        }
        list.Clear();


    }


}
