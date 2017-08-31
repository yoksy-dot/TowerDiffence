using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BuildNewTower : MonoBehaviour {


	public GameObject ui;
	public GameObject tower1,tower2,tower3,tower4;

	private bool click;
	private GameObject rootobj;

	private Text _text;

	// Use this for initialization
	void Start () {
		rootobj = transform.root.gameObject;
		//ui.SetActive(false);
		click = false;
		_text = ui.transform.Find("name").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void maketower()
	{
		click = !click;
		ui.SetActive(click);
		_text.text = gameObject.name;
	}

    public void TowerUnAct()
    {
        click = false;
        ui.SetActive(click);
    }

	public void BuildTower(int num)
	{
        //空き地を消してタワーを立てる関数
		Destroy(gameObject);
		Destroy(ui.gameObject);
		GameObject Tower;
		switch (num)
		{
			case 0:
				Tower = (GameObject)Instantiate(tower1, rootobj.transform.position, rootobj.transform.rotation);
				break;
			case 1:
				Tower = (GameObject)Instantiate(tower2, rootobj.transform.position, rootobj.transform.rotation);
				break;
			case 2:
				Tower = (GameObject)Instantiate(tower3, rootobj.transform.position, rootobj.transform.rotation);
				break;
			case 3:
				Tower = (GameObject)Instantiate(tower4, rootobj.transform.position, rootobj.transform.rotation);
				break;
			default:
				break;

		}
	}
}
