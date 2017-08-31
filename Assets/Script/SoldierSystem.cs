using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class SoldierSystem : MonoBehaviour
{

    public GameObject BattleEnemy;//今ブロックしている敵情報

    public GameObject StartPoint;//出現位置保持
    private Vector3 Target;
    private GameObject _canvas;

    private float NowHP;
    private int ID;
    //private float def;


    private Vector3 direction;//向き
    private bool running,running2;
    
    private bool near;//近づけたらコルーチンをオフにする



    private SoldierTowerSystem tower;
    private EnemyData EData;
    //private NavSystem nav;
    private CharacterController controller;
    private NavMeshAgent age;
    private SphereCollider sphere;

    private enum Type
    {
        Nomal,Air,Hide
    }


    // Use this for initialization
    void Start()
    {
        tower = transform.parent.GetComponent<SoldierTowerSystem>();
        controller = GetComponent<CharacterController>();
        sphere = GetComponent<SphereCollider>();
        //_canvas = GameObject.Find("Canvas").gameObject;
        near = false;

        NowHP = tower.SoldierHP;

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (NowHP <= 0)//死んだら
            {
                Destroy(gameObject);
                if (age != null)
                    age.enabled = true;
            }

            if (EData != null)
            {
                //Debug.Log("aqw");
                //if (BattleEnemy == null)
                //{
                //Debug.Log("ghghgh");
                sphere.enabled = true;
                if (age != null)
                    age.enabled = true;
                //near = false;
                //}
            }

            if (EData == null)
                near = false;


            if (tower.search.Nomal == true && tower.search.Hide == true && !running2)//通常敵と隠密敵が混在なら
            {
                //Debug.Log(tower.search.Re_NomalLength());
                if (tower.search.Re_NomalLength() <= tower.search.Re_HideLength())
                {
                    Target = SearchTargetFunc(ID,Type.Nomal);
                }
                else
                {
                    Target = SearchTargetFunc(ID, Type.Hide);
                }
            }
            else if (tower.search.Nomal == true)//通常のみ
            {
                //Debug.Log(tower.search.colList_nomal[0]);
                Target = SearchTargetFunc(ID, Type.Nomal);
            }
            else if (tower.search.Hide == true)//隠密のみ
            {
                Target = SearchTargetFunc(ID, Type.Hide);
            }
            else
            {
                Target = StartPoint.transform.position;
            }

            if (!near)
                StartCoroutine("MoveSoldierFunc");//移動

        }
        catch(MissingReferenceException e)
        {
            Debug.Log("索敵エラー");
            tower.search.ForErrorFlags();
        }
    }

    //兵士移動コルーチン
    IEnumerator MoveSoldierFunc()
    {
        if (running)//コルーチンが終わってないならブレイク
            yield break;
        running = true;

        direction = Target - transform.position;//向きベクトル決定
        if (BattleEnemy != null && direction.sqrMagnitude < 2)//十分に近いなら
        {
            Debug.Log("aaaaas");
            near = true;
            yield return null;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z)), 90.0f * Time.deltaTime);
        controller.Move(direction * tower.SoldierMoverSpeed / 100);


        
        yield return null;//次のフレームで移動
        running = false;
    }
    int aaa = 0;
    //兵士攻撃コルーチン
    //外部から動かす
    IEnumerator AttackSoldierFunc()
    {
        
        if (running2 /*|| BattleEnemy == null*/)//コルーチンが終わってない||敵情報がない ->break
            yield break;
        running2 = true;
        
        if (EData == null)
        {
            yield return null;
        }

        EData.Now_HP -= tower.SoldierATK;//敵の体力を減らす

        if (EData.Now_HP <= 0)//倒したとき
        {
            sphere.enabled = true;
            if (age != null)
                age.enabled = true;

            //near = false;
            running2 = false;
            yield break;
        }
        
        yield return new WaitForSeconds(tower.SoldierAtkInterval /* Time.deltaTime * 10*/);//規定のフレームで攻撃
        running2 = false;
    }

    void OnTriggerStay(Collider coll)//いるとき
    {
        
        if(coll.tag == "NomalEnemy" || coll.tag == "HideEnemy" && !near && !running2)
        {
            //Debug.Log("aasss");
            near = true;
            sphere.enabled = false;
            BattleEnemy = coll.gameObject;
            age = BattleEnemy.GetComponent<NavMeshAgent>();
            EData = BattleEnemy.GetComponent<EnemyData>();
            age.enabled = false;
        }
        //

    }


    public void startcolcol()
    {
        StartCoroutine("AttackSoldierFunc");
    }

    private Vector3 SearchTargetFunc(int ID, Type type)
    {
        Vector3 sore;
        switch (type)
        {
            case Type.Nomal:
                if (tower.search.colList_nomal.Count < ID)
                {
                    sore = tower.search.colList_nomal[tower.search.colList_nomal.Count].transform.position;
                }
                else
                {
                    sore = tower.search.colList_nomal[ID].transform.position;
                }
                
                break;
            case Type.Air:
                if (tower.search.colList_Air.Count < ID)
                {
                    sore = tower.search.colList_Air[tower.search.colList_Air.Count].transform.position;
                }
                else
                {
                    sore = tower.search.colList_Air[ID].transform.position;
                }
                
                break;
            case Type.Hide:
                if (tower.search.colList_Hide.Count < ID)
                {
                    sore = tower.search.colList_Hide[tower.search.colList_Hide.Count].transform.position;
                }
                else
                {
                    sore = tower.search.colList_Hide[ID].transform.position;
                }
                
                break;
            default:
                Debug.Log("error! SearchTargetFunc");
                sore = new Vector3(0,0,0);
                break;
        }
        

        return sore;
    }
}