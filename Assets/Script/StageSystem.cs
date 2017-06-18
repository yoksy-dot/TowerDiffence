using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour {

    //public float StartInterval;
    public float[] interval;
    public GameObject[] wave;
    public int EnemyNum;//敵の数の把握
    public int Endurance;//拠点の耐久
    public int HavePoint;

    private int WaveNum;//ウェーブ状況確認用
    private float timer;

    private int hoge;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i <= 20; i++)
        {
            if (wave[i] == null)
            {
                break;
            }
            EnemyNum += wave[i].transform.childCount;
        }

        WaveNum = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(EnemyNum);
        timer += Time.deltaTime;
        if(Endurance <= 0)//耐久0ならゲームオーバー
        {

        }

        if (timer >= interval[WaveNum])//初期待機
        {
            wave[WaveNum].SetActive(true);
            timer = 0;
            if (WaveNum < wave.Length - 1)
            {
                WaveNum++;
            }
        }
    }
}
