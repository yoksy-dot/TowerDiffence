using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject BombObj;

    public float ATK;
    public float BreakTime;
    /*爆破関係*/
    public bool CanBomb;


    private float timer;
    private BombSystem bombsys;

	// Use this for initialization
	void Start () {
        if(CanBomb)
            bombsys = BombObj.GetComponent<BombSystem>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= BreakTime)
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

            //Debug.Log("AAAAAA!");
        }
    }
}
