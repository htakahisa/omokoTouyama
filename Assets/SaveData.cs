using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{

    private Vector3 mapNoIchi;

    private Dictionary<string, int> omokoData = new Dictionary<string, int>();
    private Dictionary<string, int> touyamaData = new Dictionary<string, int>();

    private int okane = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMapNoIchi(Vector3 position) {
        this.mapNoIchi = position;
    }
    public Vector3 getMapNoIchi() {
        return this.mapNoIchi;
    }



    public Dictionary<string, int> getOmoko() {
        return this.omokoData;
    }
    public Dictionary<string, int> getTouyama() {
        return this.touyamaData;
    }

    public void setOmoko(int hp, int kougeki, int speed, int ex) {
        this.omokoData["hp"] = hp;
        this.omokoData["kougeki"] = kougeki;
        this.omokoData["speed"] = speed;
        this.omokoData["ex"] = ex;
    }

    public void setTouyama(int hp, int kougeki, int speed, int ex) {
        this.touyamaData["hp"] = hp;
        this.touyamaData["kougeki"] = kougeki;
        this.touyamaData["speed"] = speed;
        this.touyamaData["ex"] = ex;
    }

    public void addOkane(int okane) {
        this.okane += okane;
    }
    public void minusOkane(int okane) {
        this.okane -= okane;
    }

    public int getOkane() {
        return this.okane;
    }
}
