using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavSystem : MonoBehaviour {
	public GameObject StartPoint;
	public GameObject GoalPoint;

	private NavMeshAgent nav;
    private float randmize = 1.0f;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();

        nav.destination = GoalPoint.transform.position;//ゴール地点設定

        this.transform.position = new Vector3(StartPoint.transform.position.x + Random.Range(0.0f, randmize), StartPoint.transform.position.y, StartPoint.transform.position.z + Random.Range(0.0f, randmize));


    }

    // Update is called once per frame
    void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    transform.position = StartPoint.transform.position;//デバッグ用
        //}
    }

    //ゴールまでの値を返す
    public float Re_GoalLength()
    {
        if (nav.pathPending)
        {
            return -1;
        }

        NavMeshPath path = nav.path; //経路パス（曲がり角座標のVector3配列）を取得
        float dist = 0f;
        Vector3 corner = transform.position; //自分の現在位置
                                             //曲がり角間の距離を累積していく
        for (int i = 0; i < path.corners.Length; i++)
        {
            Vector3 corner2 = path.corners[i];
            dist += Vector3.Distance(corner, corner2);
            corner = corner2;
        }

        return dist;

        
    }
}
