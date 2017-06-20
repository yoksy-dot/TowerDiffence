using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //BulletのPublicは基本的に触らないこと

    public GameObject ShootTower;//これを発射したタワー
    public GameObject BombObj;

    public float ATK;
    public float BreakTime;
    /*爆破関係*/
    public bool CanBomb;


    protected float timer;
    protected BombSystem bombsys;

    //オーバーライド可
    public virtual void Start () {
        if(CanBomb)
            bombsys = BombObj.GetComponent<BombSystem>();
        timer = 0;
	}

    //オーバーライド可
    public virtual void Update () {
        TimerCount();

        if (timer >= BreakTime)
        {
            Destroy(gameObject);
            timer = 0;
        }
	}

    void OnTriggerEnter(Collider coll)//弾が当たった時 敵に動いてほしくないのでtriggerつける
    {
        if (coll.gameObject.tag == "NomalEnemy" || coll.tag == "AirEnemy" || coll.tag == "HideEnemy")
        {
            if (CanBomb)//爆発処理
            {
                bombsys.MakeBomb(BombObj, transform, ATK);
            }
            else
            {
                Destroy(gameObject);
                timer = 0;
            }

            
        }

        //if (coll.gameObject.tag == "Search")//射程外なら何もせずに削除
        //{
        //    Destroy(gameObject);
        //    timer = 0;
        //}
    }

    protected void TimerCount()
    {
        timer += Time.deltaTime;
    }
}
