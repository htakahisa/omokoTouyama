using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hipo : Cha {
    // Start is called before the first frame update
    int hp = 200;
    int kougeki = 10;
    string name = "ひぽ";
    int speed = 10;
    int ex = 20;

    int okane = 100;

    void Start() {
        setting(this.hp, this.kougeki, this.name, this.speed, this.ex);
        setOkane(this.okane);
        setTeki();
    }

    // Update is called once per frame
    void Update() {

    }



}