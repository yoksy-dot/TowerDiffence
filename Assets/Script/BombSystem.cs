using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSystem : MonoBehaviour {

    public float BombATK;
    public float Speed;
    public float Distance;

    private float i = 0.4f;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Distance >= i)
        {
            transform.localScale = new Vector3(i, i, i);
            i += Speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
           
        }
    }

    public void MakeBomb(GameObject Prefab, Transform qwe, float atk)
    {
        GameObject Bullet = (GameObject)Instantiate(Prefab, qwe.position, qwe.rotation);
        Rigidbody Bullet1Rigidbody = Bullet.GetComponent<Rigidbody>();
        BombATK = atk;
    }
}
