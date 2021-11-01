using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTools : MonoBehaviour
{
    IBullet bullet;
    Transform target;
    public bool flag = true;
    public void Init(IBullet bullet, Transform target)
    {
        this.bullet = bullet;
        this.target = target;
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) <=0.5f)
        {
            if(flag)
            {
                MsgCenter.Ins.SendMsg("UnAttack");
                bullet.Dead();
                gameObject.GetComponent<DistanceTools>().enabled = false;
                flag = false;
            }
            
           
        }
    }
}
