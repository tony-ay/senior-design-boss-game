using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour {

    private Renderer rend;
    private GameObject boss;
    private CircleCollider2D fbCollider;

    private Vector3 targetVector;

    private int timer;
    private bool firing;

    private int maxTime = 100;
    private float speed = 5f;
    private int damage = 50;

    // Use this for initialization
    void Start () {
        //gameObject.tag = "bossFireball";
        boss = GameObject.Find("boss");
        rend = GetComponent<Renderer>();
        fbCollider = GetComponent<CircleCollider2D>();
        Reset();
    }
	
	// Update is called once per frame
	void Update () {
        if (firing) {
            if (timer > 0) {
                timer--;
                transform.Translate(targetVector.normalized * speed * Time.deltaTime);
            }
            else {
                Reset();
            }
        }
    }

    void Reset() {
        print("bossFireball reset");
        rend.enabled = false;
        fbCollider.enabled = false;
        firing = false;
        targetVector.Set(0, 0, 0);
        transform.position.Set(0, 0, 0);
        timer = 0;
    }

    public void Fire(Vector3 targetPos) {
        transform.position = boss.transform.position;
        rend.enabled = true;
        fbCollider.enabled = true;
        targetVector = targetPos - transform.position;
        targetVector.z = 0;
        timer = maxTime;
        firing = true;
    }

    public bool IsFiring() {
        return firing;
    }

    public void EnableRenderer() {
        rend.enabled = true;
    }

    public void DisableRenderer() {
        rend.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        print("bfb hit");

        if (coll.gameObject.name == "player") {
            Reset();
            print("hit player");
            PlayerValues.Health -= damage;
            PlayerValues.debuffMod = 0.2f;
        }
    }
}
