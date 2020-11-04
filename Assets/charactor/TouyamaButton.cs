using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouyamaButton : MonoBehaviour{

    private Kantoku kantoku;
    private Omoko omoko;
    private Touyama touyama;
    private Hipo hipo;

    // Start is called before the first frame update
    void Start()
    {
        kantoku = GameObject.Find("Kantoku").GetComponent<Kantoku>();
        omoko = GameObject.Find("Omoko").GetComponent<Omoko>();
        touyama = GameObject.Find("Touyama").GetComponent<Touyama>();
        hipo = GameObject.Find("Hipo").GetComponent<Hipo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * 攻撃ボタンでおされる
     */
    public void kougeki() {

        if (this.GetComponent<Image>().color != Color.gray) {
            kantoku.kougekisuru(touyama, hipo);

            // 色を変える
            this.GetComponent<Image>().color = Color.gray;
        }
    }    
}
