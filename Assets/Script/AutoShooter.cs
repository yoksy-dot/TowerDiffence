using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour {

    public void ShotOnly(Transform qwe, GameObject Prefab, float Speed, float atk, float distance)
    {//発射する弾の情報も載せたい

        // プレファブから砲弾(Bullet1)オブジェクトを作成し、それをBullet1という名前の箱に入れる。
        GameObject Bullet1 = (GameObject)Instantiate(Prefab, qwe.position, qwe.rotation);

        // Rigidbodyの情報を取得し、それをBullet1Rigidbodyという名前の箱に入れる。
        Rigidbody Bullet1Rigidbody = Bullet1.GetComponent<Rigidbody>();

        Bullet BulletData = Bullet1.GetComponent<Bullet>();

        BulletData.ATK = atk;
        BulletData.BreakTime = distance;
        // Bullet1Rigidbodyにz軸方向の力を加える。
        Bullet1Rigidbody.AddForce(qwe.forward * Speed);

    }
}
