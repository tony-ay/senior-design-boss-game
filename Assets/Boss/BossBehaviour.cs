using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {
    private Renderer rend;

    private int timer;
    private int timerMax = 200;

    private Vector3 targetVector;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        if (rend.enabled) {
            if (BossValues.Health <= 0) {
                rend.enabled = false;
            }
            else {
                if (timer > 0) {
                    timer--;
                    transform.Translate(targetVector.normalized * BossValues.Speed * Time.deltaTime);
                }
                else {
                    RandomizeMovevemnt();
                    timer = timerMax;
                }
            }
        }
    }

    void RandomizeMovevemnt() {
        targetVector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }
}
