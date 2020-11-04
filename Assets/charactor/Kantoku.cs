using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Kantoku : MonoBehaviour
{

    private Text text;
    private AudioSource audioSource;
    private TekiKantoku tekiKantoku;
    private List<List<Cha>> tekiList = new List<List<Cha>>();

    private SaveData sentouSaveData;

    private Touyama touyama;
    private Omoko omoko;

    private Text touyamaHp;
    private Text omokoHp;

    private Button touyamaButton;
    private Button omokoButton;

    private List<List<Cha>> kougekiMap = new List<List<Cha>>();

    // Start is called before the first frame update
    void Start()
    {
        this.text = GameObject.Find("message").GetComponent<Text>();
        this.touyamaHp = GameObject.Find("touyamaHp").GetComponent<Text>();
        this.omokoHp = GameObject.Find("omokoHp").GetComponent<Text>();

        this.touyama = GameObject.Find("Touyama").GetComponent<Touyama>();
        this.omoko = GameObject.Find("Omoko").GetComponent<Omoko>();

        this.touyamaButton = GameObject.Find("touyamabutton").GetComponent<Button>();
        this.omokoButton = GameObject.Find("omokobotan").GetComponent<Button>();


        this.audioSource = GetComponent<AudioSource>();

        this.tekiKantoku = GameObject.Find("TekiKantoku").GetComponent<TekiKantoku>();


        this.sentouSaveData = GameObject.Find("SentouSaveData").GetComponent<SaveData>();




    }

    // Update is called once per frame
    void Update()
    {
        // hp を設定
        this.touyamaHp.text = "HP :" + this.touyama.getHp();
        this.omokoHp.text = "HP :" + this.omoko.getHp();
    }





    public void kougekisuru(Cha suru, Cha sareru) {

        List<Cha> list = new List<Cha>();
        list.Add(suru);
        list.Add(sareru);
        kougekiMap.Add(list);

        if (kougekiMap.Count == 2) {

            List<Cha> teki = this.tekiKantoku.gettekikougeki();

            // 敵リスト作成
            this.tekiList.Add(teki);

            kougekiMap.Add(teki);

            // 素早さ順にする
            kougekiMap.Sort((c1, c2) => (c2[0].getSpeed() - c1[0].getSpeed()));


            this.kougekiKaishi();
        }

    }


    async private void kougekiKaishi() {
        // 敵を全員倒したら field に戻る
        bool taoshita = false;

        foreach (List<Cha> list in kougekiMap) {

            Cha suru = null;
            foreach (Cha c in list) {
                // 攻撃する人を設定する
                if (suru == null) {
                    suru = c;
                    continue;
                }
                // 攻撃される人に攻撃する
                this.kougeki(suru, c);


                await Task.Delay(1000);



                foreach (List<Cha> t in this.tekiList) {
                    if (t[0] != null) {
                        taoshita = false;
                        break;
                    } else {
                        taoshita = true;
                    }
                }
            }
            if (taoshita) {
                break;
            }

        }



        // リストを初期化する
        this.kougekiMap = new List<List<Cha>>();
        this.tekiList = new List<List<Cha>>();

        if (taoshita) {
            //シーン移動

            sentouSaveData.setOmoko(omoko.getHp(), omoko.getKougeki(), omoko.getSpeed(), omoko.getEx());
            sentouSaveData.setTouyama(touyama.getHp(), touyama.getKougeki(), touyama.getSpeed(), touyama.getEx());


            await Task.Delay(3000);
            SceneManager.LoadScene("field");
        }

        // ボタンの色を戻す
        this.touyamaButton.GetComponent<Image>().color = Color.white;
        this.omokoButton.GetComponent<Image>().color = Color.white;

    }


    private void kougeki(Cha suru, Cha sareru) {
        text.text = "";

        // 音を出す
        this.audioSource.PlayOneShot(audioSource.clip);

        text.text = suru.getName() + " が" + sareru.getName() + " にこうげきした!" + "\n";

        // ダメージは 10% のランダム補正を入れる
        int kougeki = suru.getKougeki() + (int)(suru.getKougeki() * Random.Range(-0.1f, 0.1f));

        text.text = text.text + kougeki + " のダメージ!" + "\n";

        bool sibou = sareru.kougekiSareta(kougeki);


        if (sibou) {
            text.text = text.text + sareru.getName() + " をたおした!" + "\n";

            // 敵の時はお金を獲得
            if (sareru.getIsTeki()) {
                sentouSaveData.addOkane(sareru.getOkane());
            }
        }

    }

}
