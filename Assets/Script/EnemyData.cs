using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyData : MonoBehaviour {

    public float Max_HP;
    public float Now_HP;
    public float ATK;
    public float Speed;//Navに代入する用
    public int BlockNum;//現在のブロック数

    private NavMeshAgent Nav;
    private Bullet bullet;
    private Bullet_Missile bullet2;
    private BombSystem bomsys;
    private StageSystem stage;

    // Use this for initialization
    void Start () {
        Now_HP = Max_HP;
        

        stage = GameObject.Find("Stage").GetComponent<StageSystem>();
        if (stage == null)
        {
            Debug.Log("hoooo");
        }

        /*ナビシステム関連*/
        Nav = GetComponent<NavMeshAgent>();
        Nav.speed = Speed;

        

    }
	
	// Update is called once per frame
	void Update () {
		
        if(Now_HP <= 0)//死んだとき
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bullet")//弾に当たった時
        {
            bullet = coll.gameObject.GetComponent<Bullet>();
            //Debug.Log(bullet.ATK);
            Now_HP -= bullet.ATK;
            
        }
        else if(coll.gameObject.tag == "BulletMissile")
        {
            bullet2 = coll.gameObject.GetComponent<Bullet_Missile>();
            Now_HP -= bullet2.ATK;
        }

        if (coll.gameObject.tag == "Bomb")
        {
            bomsys = coll.gameObject.GetComponent<BombSystem>();

            Now_HP -= bomsys.BombATK;
        }

        if (coll.gameObject.tag == "Goal")//拠点到達時
        {
            stage.Endurance--;
            Destroy(gameObject);
        }
    }
}
