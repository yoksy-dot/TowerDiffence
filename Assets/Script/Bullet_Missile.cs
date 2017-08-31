using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Missile : Bullet
{
    //追尾弾のスクリプト
    //Bulletクラス継承

    public float CanRotation;//回転制限
    public float Power;//推進力
    public GameObject Target;//標的

    private Vector3 direction;//向き
    private TowerSystem tower;
    private bool fire;

    // Use this for initialization
    public override void Start () {
        if (CanBomb)
            bombsys = BombObj.GetComponent<BombSystem>();
        timer = 0;
        tower = ShootTower.GetComponent<TowerSystem>();
        Target = tower.Target;//目標決定
        fire = false;
    }

    // Update is called once per frame
    public override void Update () {
        TimerCount();

        if (Target == null)
        {
            Destroy(gameObject);
            timer = 0;
            fire = false;
            return;
        }

        direction = Target.transform.position - transform.position;//向きベクトル決定
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z)), CanRotation * Time.deltaTime);
        fire = true;
    }

    void FixedUpdate()
    {
        if (fire) {
            GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * Power); // 正面方向に移動
            fire = false;
        }
    }
}
