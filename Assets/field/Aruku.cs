using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aruku : MonoBehaviour
{

    int muki = 0;
    float walkSpeed = 0.01f;
    protected int notWalk = 0;


    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        this.move(transform);

    }

    public void move(Transform transform) {

        // up
        if (this.muki == 1 && notWalk != 1) {
            transform.Translate(0, -walkSpeed, 0);
        }
        // right
        if (this.muki == 2 && notWalk != 2) {
            transform.Translate(-walkSpeed, 0, 0);
        }
        // down
        if (this.muki == 3 && notWalk != 3) {
            transform.Translate(0, walkSpeed, 0);
        }
        // left
        if (this.muki == 4 && notWalk != 4) {
            transform.Translate(walkSpeed, 0, 0);
        }
    }


    public void up() {
        this.muki = 1;
    }

    public void right() {
        this.muki = 2;
    }


    public void down() {
        this.muki = 3;
    }


    public void left() {
        this.muki = 4;
    }

    public void tomaru() {
        this.muki = 0;
    }

    public void setNotWalk() {
        this.notWalk = this.muki;
    }

    public void canWalk() {
        this.notWalk = 0;
    }

}
