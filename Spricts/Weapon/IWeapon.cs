using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WEAPON_ENUM
{
    Null,
    type1,
    type2,
    type3,
}

public abstract class IWeapon
{
    protected GameObject bullet;
    protected GameObject WeaponPos;
    protected WEAPON_ENUM WeaponType;
    protected List<IBullet> bullets;
    public int Id;

    protected float direction = 1;


    public IWeapon()
    {
        bullets = new List<IBullet>();
    }

    public void SetDirection(int num)
    {
        direction = num;
    }

    public void Frie()
    {
        reload();
    }

    public GameObject CreatBullet()
    {
      // Debug.Log("生成子弹");
        return GameObject.Instantiate(bullet);
    }

    public void SetBullet(GameObject obj)
    {
        bullet = obj;
    }

    public void SetWeaponPos(GameObject obj)
    {
        WeaponPos = obj;
    }

    public virtual void Release()
    {

    }

    public abstract void reload();
    public virtual void Update()
    {

        BulletsUpdate();
        DelBullet();
    }

    public abstract void BulletsUpdate();

    public abstract void DelBullet();
   


    public WEAPON_ENUM GetWeaponType()
    {
        return WeaponType;
    }

    public void DeleteWeapon()
    {
        WeaponPos = null;
        bullet = null;
    }

    public void Dead()
    {
        foreach (var item in bullets)
        {
            item.isHead = true;
            item.Dead();
        }
        DelBullet();
    }




}
