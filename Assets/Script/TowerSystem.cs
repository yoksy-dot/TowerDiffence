using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSystem : MonoBehaviour {
    public GameObject SearchArea;
    public GameObject ShootPoint;
    public GameObject Bullet;

    public float ATK;//攻撃力
    public float Distance;//攻撃範囲
    public float Interval;//攻撃頻度
    public float ShootSpeed;//弾の速度
    public GameObject Target;//狙い

    protected bool fire;
    protected float timer;

    protected SearchFlags Search;
    protected AutoShooter shooter;

    // Use this for initialization
    void Start () {
        Search = SearchArea.GetComponent<SearchFlags>();
        shooter = ShootPoint.GetComponent<AutoShooter>();

        timer = 0;
        fire = false;
    }
	
	//オーバーライド可
	public virtual void Update () {
        TimerCount();

        if (Search.Nomal)//敵発見
        {
            if (Search.colList_nomal[0] == null)
            {
                return;
            }
            //Debug.Log("aaaaaa");
            Target = Search.colList_nomal[0];
            ShootPoint.transform.LookAt(Search.colList_nomal[0].transform);
            if (timer >= Interval)
            {
                fire = true;
                timer = 0;
            }
            //Debug.Log(timer);
        }
	}

    void FixedUpdate()
    {
        if (fire)
        {
            
            shooter.ShotOnly(ShootPoint.transform, Bullet, gameObject);
            fire = false;
        }
    }

    protected void TimerCount()
    {
        timer += Time.deltaTime;
    }


}
