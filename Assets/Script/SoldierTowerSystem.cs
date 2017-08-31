using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierTowerSystem : MonoBehaviour {
    public GameObject MovingArea;//兵士の移動範囲
    public GameObject SoldierPrefabs;//兵士プレハブ
    public GameObject[] SoldierDefaltPos = new GameObject[4];//兵士の待機場所 
    

    public int SoldierMaxCount;//塔一つにつき何人だせるか = Lv
    private int SoldierNowCount;//今、何人いるか
    //public int TowerLv;//1レベルにつき1人出せる最大4人
    public float SoldierHP;
    public float SoldierATK;
    public float SoldierDEF;
    public float SoldierMoverSpeed;//兵士の移動スピード
    public float SoldierAtkInterval;//兵士の攻撃間隔
    public float SoldierRespwanInterval;//兵士のリスポーン時間

    
    

    private bool running;

    public SearchFlags search;
    private SoldierSystem soldata;


    // Use this for initialization
    void Start () {
        SoldierNowCount = 0;
        running = false;



        search = MovingArea.GetComponent<SearchFlags>();
    }
	
	// Update is called once per frame
	void Update () {
        if (SoldierMaxCount > SoldierNowCount)//空きがあるなら
        {
            StartCoroutine("MakeSoldierFunc");
        }

        
    }

    //兵士生産
    IEnumerator MakeSoldierFunc()
    {
        if (running)//コルーチンが終わってないならブレイク
            yield break;
        running = true;

        
        GameObject sol = (GameObject)Instantiate(SoldierPrefabs,
            SoldierDefaltPos[SoldierNowCount].transform.position,
            SoldierDefaltPos[SoldierNowCount].transform.rotation);

        //メソッドに代入
        soldata = sol.GetComponent<SoldierSystem>();

        soldata.StartPoint = SoldierDefaltPos[SoldierNowCount];

        sol.transform.parent = gameObject.transform;//タワーの子にする
        SoldierNowCount++;

        yield return new WaitForSeconds(SoldierRespwanInterval);//リスポーン時間
        running = false;
    }

    
}
