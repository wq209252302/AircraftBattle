using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameLoop : MonoBehaviour
{

    SceneStageCtrl ctrl;
    //public Transform Canvas;
    //public Transform Eventsystem;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        ctrl = new SceneStageCtrl();
        ctrl.SetState(new BattleScene(ctrl), "BattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        ctrl.Update();
    }
}
