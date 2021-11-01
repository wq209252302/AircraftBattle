using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    GameObject m_go;
    IWeapon weapon;
    float time = 0;
    int HP;
    Animator anim;
    Vector3 pos;
    int count = 35;

    int killnum = 0;
    int score = 0;

    public Player()
    {
        m_go = GameObject.Instantiate(Resources.Load<GameObject>("player"));
        weapon = new Level2(2);
        weapon.SetBullet(Resources.Load<GameObject>("bullet2"));
        weapon.SetWeaponPos(m_go.transform.Find("FrieDot").gameObject);
        anim = m_go.transform.Find("laser").GetComponent<Animator>();
        //m_go.AddComponent<DragPlayer>();
        MsgCenter.Ins.AddListener("UnAttack", UnAttack);
        MsgCenter.Ins.AddListener("EnemyDead", EnemyDead);

    }

    public void EnemyDead(object obj)
    {
        object[] arr = obj as object[];
        score += (int)arr[0];
        killnum += 1;
        AircraftBattleGame.Ins.SetData(score,killnum);

    }

    public void UnAttack(object[] obj)
    {
        HP--;
        AircraftBattleGame.Ins.UnAttack();
        //Debug.Log(HP);
        if (HP <= 0)
        {
            AircraftBattleGame.Ins.UIBackShow();
            Debug.Log("死了");
            Time.timeScale = 0;
            HP = 3;

            MsgCenter.Ins.RemoveListener("UnAttack", UnAttack);
            MsgCenter.Ins.RemoveListener("EnemyDead", EnemyDead);

        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Time.time - time > 0.25f)
        {
            time = Time.time;
            AircraftBattleGame.Ins.ChangValue();

            weapon.Frie();
            count--;
            if (count <= 0)
            {
                UseSkill();
                count = 35;
            }
        }

        weapon.Update();

        m_go.transform.position = Vector3.MoveTowards(m_go.transform.position, pos, 3 * Time.deltaTime);
        //Move();
    }

    public void Move(Vector3 pos)
    {
        this.pos = pos;
        // m_go.transform.position  = pos;
    }

    public GameObject GetGameObject()
    {
        return m_go;
    }


    public void UseSkill()
    {
        anim.Play("laser");
    }

    public void SetHp(int num)
    {
        HP = num;
    }
}
