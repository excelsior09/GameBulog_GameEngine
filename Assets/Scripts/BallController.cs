using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    Text scoreUIP11;
    Text scoreUIP21;
    GameObject panelSelesai;
    Text txPemenang;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, 2).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("ScoreAtas1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("ScoreBawah1").GetComponent<Text>();
        scoreUIP11 = GameObject.Find("ScoreAtas11").GetComponent<Text>();
        scoreUIP21 = GameObject.Find("ScoreBawah21").GetComponent<Text>();
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TampilkanScore(){
        Debug.Log("Score P1:"+scoreP1+" Score P2:"+scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
        scoreUIP11.text = scoreP1 + "";
        scoreUIP21.text = scoreP2 + "";

    }
    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.name=="GawangBawah"){
            scoreP1+=1;
            TampilkanScore();
            if(scoreP1 == 5){
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Biru Menang!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(0,2).normalized;
            rigid.AddForce(arah*force);
        }
        if (coll.gameObject.name=="GawangAtas"){
            scoreP2+=1;
            TampilkanScore();
            if(scoreP2 == 5){
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Merah Menang!";
                Destroy(gameObject);
                return;
            }
            ResetBall();
            Vector2 arah = new Vector2(0,-2).normalized;
            rigid.AddForce(arah*force);
        }
        if(coll.gameObject.name=="PlayerAtas" || coll.gameObject.name=="PlayerBawah"){
            float sudut = (transform.position.x - coll.transform.position.x)*5f;
            Vector2 arah = new Vector2(sudut, rigid.velocity.y).normalized;
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(arah * force * 2);
        }
    }
}