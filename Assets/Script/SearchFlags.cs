﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchFlags : MonoBehaviour {
    public bool Nomal;
    public bool Air;
    public bool Hide;

    //private bool OnColl;


    public List<GameObject> colList_nomal = new List<GameObject>();
    public List<GameObject> colList_Air = new List<GameObject>();
    public List<GameObject> colList_Hide = new List<GameObject>();
    //public List<GameObject> ATKList = new List<GameObject>();//攻撃順に並べてここに入れる

    private EnemyData e_data;

    // Use this for initialization
    void Start () {
        Nomal = false;
        Air = false;
        Hide = false;
        //OnColl = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(colList_nomal.Count == 0)
        {
            Nomal = false;
        }

        if (colList_Air.Count == 0)
        {
            Air = false;
        }

        if (colList_Hide.Count == 0)
        {
            Hide = false;
        }
    }

    void OnTriggerStay(Collider coll)//いるとき
    {
        
        if (coll.tag == "NomalEnemy" || coll.tag == "AirEnemy" || coll.tag == "HideEnemy")
        {
            //OnColl = true;
            /*死亡処理*/
            e_data = coll.gameObject.GetComponent<EnemyData>();
            if (e_data.Now_HP <= 0)//HPが0なら
            {
                if (coll.tag == "NomalEnemy" && colList_nomal.Contains(coll.gameObject))
                {
                    //Debug.Log("llll");
                    colList_nomal.Remove(coll.gameObject);
                }

                if (coll.tag == "AirEnemy" && colList_Air.Contains(coll.gameObject))
                {
                    colList_Air.Remove(coll.gameObject);
                }

                if (coll.tag == "HideEnemy" && colList_Hide.Contains(coll.gameObject))
                {
                    colList_Hide.Remove(coll.gameObject);
                }
                //OnColl = false;
            }

            else if (e_data.Now_HP > 0)//リスト追加処理
            {
                if (coll.tag == "NomalEnemy" && !colList_nomal.Contains(coll.gameObject))
                {
                    Nomal = true;
                    colList_nomal.Add(coll.gameObject);
                }

                if (coll.tag == "AirEnemy" && !colList_Air.Contains(coll.gameObject))
                {
                    Air = true;
                    colList_Air.Add(coll.gameObject);
                }

                if (coll.tag == "HideEnemy" && !colList_Hide.Contains(coll.gameObject))
                {
                    Hide = true;
                    colList_Hide.Add(coll.gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider coll)//出ていったとき
    {
        //OnColl = false;
        if (coll.tag == "NomalEnemy"&& colList_nomal.Contains(coll.gameObject))
        {
            Nomal = false;
            colList_nomal.Remove(coll.gameObject);
        }

        if (coll.tag == "AirEnemy" && colList_Air.Contains(coll.gameObject))
        {
            Air = false;
            colList_Air.Remove(coll.gameObject);
        }

        if (coll.tag == "HideEnemy" && colList_Hide.Contains(coll.gameObject))
        {
            Hide = false;
            colList_Hide.Remove(coll.gameObject);
        }
    }

}
