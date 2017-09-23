using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStats : MonoBehaviour {
    //タワーの状態を返すスクリプト
    private bool BuildTower;

    // Use this for initialization
    void Start()
    {
        BuildTower = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isBuildTowerFunc()
        //タワーの状態を返す関数
    {
        return BuildTower;
    }

    public void ChengeBoolFunc()
        //タワーの状態を変更する関数
    {
        BuildTower = !BuildTower;
    }
}
