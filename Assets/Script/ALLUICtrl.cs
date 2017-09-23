using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALLUICtrl : MonoBehaviour {

    [SerializeField]
    private List<GameObject> CanvasList = new List<GameObject>();//自分で設定
    private List<UIStats> Stats = new List<UIStats>();

    private GameObject Panel;

    // Use this for initialization
    void Start () {
        //Debug.Log(CanvasList.Count);
        for (int i = 0; i < CanvasList.Count; i++)
        {
            //Debug.Log("asd");
            Stats.Add(CanvasList[i].GetComponent<UIStats>());
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UIController(int num)
    {
        for (int i = 0; i < CanvasList.Count; i++)
        {
            if (Stats[i].isBuildTowerFunc() )
            //タワーの状態を確認
            {
                //Debug.Log("gggggg");
                Panel = Stats[i].transform.Find("LvPanel").gameObject;//タワー
            }
            else
            {
                //Debug.Log("aaaaaaaaaaa");
                Panel = Stats[i].transform.Find("BuildPanel").gameObject;//空き地
            }

            if (i == num)//選んだやつを見つければ表示
            {
                Panel.SetActive(true);
            }
            else//ほかのＵＩは消す
            {
                Panel.SetActive(false);
            }
        }
    }

}
