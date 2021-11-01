using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IBulletFactory
{
    public override IBullet CreatFactory(int id)
    {
        IBullet bullet;
        switch (id)
        {
            case 0:
                bullet = new UsualBullet();
                bullet.SetGameObject(Resources.Load<GameObject>("bullet1"));
                break;
            case 1:
                bullet = new UsualBullet();
                bullet.SetGameObject(Resources.Load<GameObject>("bullet2"));
                break;
            case 2:
                bullet = new UsualBullet();
                bullet.SetGameObject(Resources.Load<GameObject>("bullet3"));
                break;
            case 3:
                bullet = new UsualBullet();
                bullet.SetGameObject(Resources.Load<GameObject>("bullet4"));
                break;
            default:
                bullet = new UsualBullet();
                break;
        }

        return bullet;
       
    }
}
