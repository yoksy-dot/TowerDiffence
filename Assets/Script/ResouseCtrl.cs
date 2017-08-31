using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResouseCtrl : MonoBehaviour {

    public GameObject[] TextUI = new GameObject[4];//0:LIFE 1:Money 2:Enemynum 3:
    //public GameObject[] Button = new GameObject[4];

    private Text[] text = new Text[4];
    private StageSystem  _System;
    private GameObject stage;


	// Use this for initialization
	void Start () {
        stage = GameObject.Find("Stage");
        _System = stage.GetComponent<StageSystem>();

        for (int i = 0; i < 4; i++)
        {
            text[i] = TextUI[i].GetComponent<Text>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        text[0].text = _System.Endurance + "/3";
        text[1].text = _System.HavePoint + "P";
        text[2].text = _System.CallKillEnemy() + "/" + _System.EnemyNum;

    }
}
