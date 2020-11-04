using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha : MonoBehaviour
{
    // Start is called before the first frame update

    private int hp = 0;
    private int kougeki = 0;
    private string name = "";
    private int speed = 0;
    private int ex = 0;

    private int okane = 0;

    private bool isTeki = false;
    private bool shibou = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void setting(int hp, int kougeki, string name, int speed, int ex) {
        this.hp = hp;
        this.kougeki = kougeki;
        this.name = name;
        this.speed = speed;
        this.ex = ex;
    }
    protected void setTeki() {
        this.isTeki = true;
    }
    public bool getIsTeki() {
        return this.isTeki;
    }

    protected void setOkane(int okane) {
        this.okane = okane;
    }
    public int getOkane() {
        return this.okane;
    }

    public int getKougeki() {
        return this.kougeki;
    }

    public string getName() {
        return this.name;
    }

    public int getSpeed() {
        return this.speed;
    }

    public int getHp() {
        return this.hp;
    }

    public int getEx() {
        return this.ex;
    }

    public int getLevel() {
        int baseEx = 100;
        int level = 1;
        for (int i = 0; i < 100; i++ ) {

            if (this.ex - baseEx + ( baseEx * i * 0.1) > 0) {
                continue;
            } else {
                level = i + 1;
                break;
            }
        }
        return level;
    }

    /**
     * 攻撃されたら hp から 引数の kougeki を引く
     * 倒されたら true を返す
     * まだ
     * 
     */
    public bool kougekiSareta(int kougeki) {
        this.hp = this.hp - kougeki;

        if (hp <= 0) {

            if (!this.shibou && null != gameObject) {
                this.shibou = true;
                Destroy(gameObject);
            }

            return true;
        } else {
            return false;
        }
    
    }
} 

