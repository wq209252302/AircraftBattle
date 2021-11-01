using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : IGameSystem
{
    Player player;
    float x;
    float y;
    Vector3 pos;
    public InputSystem(AircraftBattleGame game) : base(game)
    {


    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }


    public override void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    player.Move(new Vector3(-1.5f, 0, 0) * Time.deltaTime);
        //    //.m_go.transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    player.Move(new Vector3(1.5f, 0, 0) * Time.deltaTime);
        //    // m_go.transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    player.Move(new Vector3(0, 1.5f, 0) * Time.deltaTime);
        //    //m_go.transform.position += new Vector3(0, 1.5f, 0) * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    player.Move(new Vector3(0, -1.5f, 0) * Time.deltaTime);
        //    // m_go.transform.position += new Vector3(0, -1.5f, 0) * Time.deltaTime;
        //}

        if (Input.GetMouseButton(0))
        {

            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.Move(new Vector3(pos.x,pos.y,0));


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.UseSkill();
        }
    }
}
