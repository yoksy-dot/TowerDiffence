using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowerSystem : MonoBehaviour {
    public GameObject SearchArea;
    public GameObject ShootPoint;
    public GameObject Bullet;
    public GameObject UI;//使用UI


    public float ATK;//攻撃力
    public float Distance;//攻撃範囲
    public float Interval;//攻撃頻度
    public float ShootSpeed;//弾の速度
    public GameObject Target;//狙い

    protected bool fire;
    protected float timer;

    protected SearchFlags Search;
    protected AutoShooter shooter;
    private Text nametext;

    private bool click;

    // Use this for initialization
    void Start () {
        Search = SearchArea.GetComponent<SearchFlags>();
        shooter = ShootPoint.GetComponent<AutoShooter>();
        nametext = UI.transform.Find("NameText").GetComponent<Text>();

        timer = 0;
        fire = false;
        click = false;
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
                Target = Search.colList_nomal[0];
                ShootPoint.transform.LookAt(Search.colList_nomal[0].transform);
                if (timer >= Interval)
                {
                    fire = true;
                    timer = 0;
                }
            }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    click = false;
        //}

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

    public void UIViewer()//クリックされればアクティブにする
    {
        click = !click;
        UI.SetActive(click);
        nametext.text = gameObject.transform.root.name;
    }

    public void UICanceler()//ほかのオブジェクトが押されたときに呼び非アクティブ化
    {
        click = false;
        UI.SetActive(click);
    }
}
