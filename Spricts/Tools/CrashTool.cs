using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashTool : MonoBehaviour
{
    IMonster monster;
    float time = 0;

    public void Init(IMonster monster)
    {
        this.monster = monster;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet"))
        {
            collision.transform.position += new Vector3(30, 0, 0);
            monster.UnAttack();
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("laser")&&Time.time-time>0.15f)
        {
            time = Time.time;
            monster.UnAttack();
        }
    }
}
