using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : Aruku
{

    public GameObject tekiPref;
    private float kankaku = 10f;
    private float kankakuCount = 5f;

    private float walkInterval = 0.1f;
    private float walkIntervalCount = 0f;


    private List<GameObject> tekiList = new List<GameObject>();

    private SaveData saveData;
    private SaveData sentouSaveData;

    private Text info;

    // Start is called before the first frame update
    public new void Start()
    {

        for (int i = 0; i < 3; i++) {
            GameObject tekiG = Instantiate(tekiPref) as GameObject;
            tekiList.Add(tekiG);
        }



        this.saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        if (saveData.getMapNoIchi() != null) {
            transform.position = saveData.getMapNoIchi();
        }

        this.sentouSaveData = GameObject.Find("SentouSaveData").GetComponent<SaveData>();

        if (sentouSaveData.getOmoko().ContainsKey("hp")) {
            this.info = GameObject.Find("info").GetComponent<Text>();
            this.info.text = "お金 : " + this.sentouSaveData.getOkane() + " 円\n" +
                "おもこ　 HP : " + sentouSaveData.getOmoko()["hp"] + " / 経験値 :" + sentouSaveData.getOmoko()["ex"] + "\n" +
                "とうやま HP : " + sentouSaveData.getTouyama()["hp"] + " / 経験値 :" + sentouSaveData.getTouyama()["ex"] + "\n";
        }

        base.Start();
    }

    // Update is called once per frame
    public new void Update()
    {

        this.kankakuCount += Time.deltaTime;
        
        // 敵の位置移動
        if (this.kankakuCount > kankaku) {

            foreach(GameObject teki in tekiList) {

                float x = Random.Range(-6.3f, -3.3f);
                float y = Random.Range(-0.4f, -3.0f);

                teki.transform.position = new Vector3(x, y, 0);
            }

            this.kankakuCount = 0;
        }

        

        base.Update();
    }

    private void OnCollisionEnter(Collision collision) {
        this.OnCollisionStay(collision);
    }

    private void OnCollisionStay(Collision collision) {
        // 障害物にぶつかったのでとまる
        base.setNotWalk();
    }
    private void OnCollisionExit(Collision collision) {
        base.canWalk();
    }
}
