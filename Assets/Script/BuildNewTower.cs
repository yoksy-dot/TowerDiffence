using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BuildNewTower : MonoBehaviour {

    public int ID;

    [SerializeField]
    private GameObject buildpanel;
    [SerializeField]
    private GameObject LvUI;
    [SerializeField]
    private GameObject tower1,tower2,tower3,tower4,tower5;

	private bool click;
	private GameObject rootobj;
    

	private Text _text;
    private UIStats uistats;

	// Use this for initialization
	void Start () {
		rootobj = transform.root.gameObject;
		//ui.SetActive(false);
		click = false;
		_text = buildpanel.transform.Find("name").gameObject.GetComponent<Text>();
        uistats = buildpanel.GetComponentInParent<UIStats>();

	}
	
	// Update is called once per frame
	void Update () {
        _text.text = gameObject.name;
    }


	public void BuildTower(int num)
	{
        //空き地を消してタワーを立てる関数
		Destroy(gameObject);
        buildpanel.SetActive(false);
		GameObject Tower = null;
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
            case 4:
                Tower = (GameObject)Instantiate(tower5, rootobj.transform.position, rootobj.transform.rotation);
                break;
			default:
				break;

		}
        if (Tower == null)
            Debug.Log("タワー生成エラー");

        Tower.transform.parent = rootobj.transform;
        if (num >= 0 && num <= 3)
        {
            Tower.GetComponent<TowerSystem>().UI = LvUI;
            Tower.GetComponent<TowerSystem>().ID = ID;
        }
        else
        {
            Tower.GetComponent<SoldierTowerSystem>().ID = ID;
            Tower.GetComponent<SoldierTowerSystem>().UI = LvUI;
        }
        uistats.ChengeBoolFunc();
    }
}
