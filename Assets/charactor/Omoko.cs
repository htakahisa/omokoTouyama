using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Omoko : Cha {

    int hp = 200;
    int kougeki = 50;
    string name = "おもこ";
    int speed = 17;

    private Text hptext;
    private SaveData omokoSaveData;


    // Start is called before the first frame update
    void Start()
    {


        this.omokoSaveData = GameObject.Find("SentouSaveData").GetComponent<SaveData>();
        Dictionary<string, int> omokoData = this.omokoSaveData.getOmoko();
        if (omokoData.ContainsKey("hp")) {
            setting(omokoData["hp"], omokoData["kougeki"], this.name, omokoData["speed"], omokoData["ex"]);
        } else {
            setting(this.hp, this.kougeki, this.name, this.speed, 0);
        }


        

        this.hptext = GameObject.Find("omokoHp").GetComponent<Text>();
        this.hptext.text = "HP: " + hp;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
