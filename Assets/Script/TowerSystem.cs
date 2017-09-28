using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class TowerSystem : MonoBehaviour {

    public int ID;
    public GameObject SearchArea;
    public GameObject ShootPoint;
    public GameObject Bullet;
    public GameObject UI;//使用UI

    public int LV;//レベル
    public float ATK;//攻撃力
    public float Distance;//攻撃範囲
    public float Interval;//攻撃頻度
    public float ShootSpeed;//弾の速度
    public GameObject Target;//狙い
    public int LvUPCost;//レベルアップコスト
    public int AmountSold;//売却額

    protected bool fire;
    protected float timer;
    protected GameObject Stageobj;

    protected SearchFlags Search;
    protected AutoShooter shooter;
    protected Text nametext;
    protected StageSystem _stagesys;

    private bool click;

    // Use this for initialization
    void Start () {
        Search = SearchArea.GetComponent<SearchFlags>();
        shooter = ShootPoint.GetComponent<AutoShooter>();
        
        nametext = UI.transform.Find("NameText").GetComponent<Text>();
        GameObject UICtrl = GameObject.Find("UICtrlObj").gameObject;
        ALLUICtrl _ALLUICtrl = UICtrl.GetComponent<ALLUICtrl>();

        timer = 0;
        fire = false;
        click = false;

        /*イベント関連*/
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();

        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((x) => 
            {
                //Debug.Log("Enter!");
                _ALLUICtrl.UIController(ID);
            }
        );
        trigger.triggers.Add(entry);
        /*ここまで*/

        Stageobj = GameObject.Find("Stage").gameObject;
        _stagesys = Stageobj.GetComponent<StageSystem>();
    }
	
	//オーバーライド可
	public virtual void Update () {
        TimerCount();
        nametext.text = gameObject.name;

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

    public void LVUpeer()//LvUP処理
    {

        _stagesys.InMoney(LvUPCost * (-1) * LV);
    }
    
}
