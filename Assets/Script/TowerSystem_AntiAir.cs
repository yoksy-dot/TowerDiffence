﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSystem_AntiAir : TowerSystem {
	/*対空用TowerSystemオーバーライド*/

	//オーバーライド
	public override void Update () {
        TimerCount();
        nametext.text = gameObject.name;
        if (Search.Nomal)
        {
            return;
        }

        if (Search.Air)//敵発見
        {
            if (Search.colList_Air[0] == null)
            {
                return;
            }
            ShootPoint.transform.LookAt(Search.colList_Air[0].transform);
            if (timer >= Interval)
            {
                fire = true;
                timer = 0;
            }
        }

    }
}
