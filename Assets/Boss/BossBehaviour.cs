using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {
    private Renderer rend;

    private int timer;
    private int timerMax = 200;

    private float attackTimer;
    private float attackTimerMax = 10;

    private Vector3 targetVector;

    private BossFireball fireball;
    private GameObject player;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        timer = 0;
        attackTimer = 0;

        fireball = GameObject.Find("bossFireball").GetComponent<BossFireball>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update() {
        if (rend.enabled) {
            if (BossValues.Health <= 0) {
                rend.enabled = false;
            }
            else {
                //movement
                if (timer > 0) {
                    timer--;
                    transform.Translate(targetVector.normalized * BossValues.Speed * Time.deltaTime);
                }
                else {
                    RandomizeMovement();
                    timer = timerMax;
                }

                //attack
                if (attackTimer > 0) {
                    attackTimer -= Time.deltaTime;
                }
                else {
                    print("boss firing");
                    fireball.Fire(player.transform.position);
                    attackTimer = attackTimerMax;
                }
            }
        }
    }

    void RandomizeMovement() {
        targetVector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }
}
