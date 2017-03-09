using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {
    private Renderer rend;
    private bool firing;
    private Vector3 targetVector;

    private GameObject player;

    private int timer;

    // Use this for initialization
    void Start() {
        gameObject.tag = "projectile";
        player = GameObject.Find("player");
        rend = GetComponent<Renderer>();
        Reset();
    }

    // Update is called once per frame
    void Update() {
        if (firing) {
            if (timer > 0) {
                timer--;
                transform.Translate(targetVector.normalized * ProjectileValues.speed * Time.deltaTime);
            }
            else {
                print("Reset");
                Reset();
            }
        }
    }

    void Reset() {
        rend.enabled = false;
        firing = false;
        targetVector.Set(0,0,0);
        transform.position.Set(0, 0, 0);
        timer = 0;
    }

    public void Fire(Vector3 targetPos) {
        print("Firing");
        transform.position = player.transform.position;
        rend.enabled = true;
        targetVector = targetPos - transform.position;
        targetVector.z = 0;
        timer = ProjectileValues.maxTime;
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
        print("hit");

        Reset();

        if (coll.gameObject.name == "boss") {
            print("hit boss");
            BossValues.Health -= ProjectileValues.damage;
        }
        
    }
}
