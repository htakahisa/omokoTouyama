using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touyama : Cha
{
    int hp = 100;
    int kougeki = 100;
    string name = "とうやま";
    int speed = 15;

    private Text hptext;

    private SaveData sentouSaveData;

    // Start is called before the first frame update
    void Start()
    {
        this.sentouSaveData = GameObject.Find("SentouSaveData").GetComponent<SaveData>();
        Dictionary<string, int> touyamaData = this.sentouSaveData.getTouyama();
        if (touyamaData.ContainsKey("hp")) {
            setting(touyamaData["hp"], touyamaData["kougeki"], this.name, touyamaData["speed"], touyamaData["ex"]);
        } else {
            setting(this.hp, this.kougeki, this.name, this.speed, 0);
        }


        this.hptext = GameObject.Find("touyamaHp").GetComponent<Text>();
        this.hptext.text = "HP: " + hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
