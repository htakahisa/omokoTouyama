using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teki : Aruku
{

    private SaveData saveData;
    private Aruku map;



    public new void Start() {
        this.saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        this.map = GameObject.Find("map").GetComponent<Aruku>();



        base.Start();
        
    }

    public new void Update() {

        this.map.move(transform);

    }


    // おもことうやまがぶつかった
    private void OnTriggerEnter(Collider other) {

        if (this.saveData == null) {
            return;
        }
        if (this.map == null) {
            return;
        }

        // 位置の保存
        this.saveData.setMapNoIchi(map.transform.position);

        //シーン移動
        SceneManager.LoadScene("sento");
    }

    
     


}
