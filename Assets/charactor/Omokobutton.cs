using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Omokobutton : MonoBehaviour {

    private Kantoku kantoku;
    private Touyama touyama;
    private Omoko omoko;
    private Hipo hipo;

    // Start is called before the first frame update
    void Start() 
    {
        kantoku = GameObject.Find("Kantoku").GetComponent<Kantoku>();
        touyama = GameObject.Find("Touyama").GetComponent<Touyama>();
        omoko = GameObject.Find("Omoko").GetComponent<Omoko>();
        hipo = GameObject.Find("Hipo").GetComponent<Hipo>();
    }

    // Update is called once per frame
    void Update() {

    }

    /**
     * 攻撃ボタンでおされる
     */
    public void kougeki() {

        if (this.GetComponent<Image>().color != Color.gray) {

            kantoku.kougekisuru(omoko, hipo);

            // 色を変える
            this.GetComponent<Image>().color = Color.gray;
        }

    }
}
