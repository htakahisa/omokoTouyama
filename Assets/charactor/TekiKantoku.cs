using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TekiKantoku : MonoBehaviour
{
    private Omoko omoko;
    private Touyama touyama;
    private Hipo hipo;

    // Start is called before the first frame update
    void Start()
    {
        omoko = GameObject.Find("Omoko").GetComponent<Omoko>();
        touyama = GameObject.Find("Touyama").GetComponent<Touyama>();
        hipo = GameObject.Find("Hipo").GetComponent<Hipo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Cha> gettekikougeki (){

        List<Cha> list = new List<Cha>();

        list.Add(hipo);
        list.Add(touyama);

        return list;
    }
}
