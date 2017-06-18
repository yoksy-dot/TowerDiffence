using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class NavSystem : MonoBehaviour {
	public GameObject StartPoint;
	public GameObject GoalPoint;

	private NavMeshAgent nav;
	

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();

        nav.destination = GoalPoint.transform.position;//ゴール地点設定

        this.transform.position = StartPoint.transform.position;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = StartPoint.transform.position;//デバッグ用
        }
    }
}
