using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private ProjectileBehaviour pB;

    // Use this for initialization
    void Start() {
        pB = GameObject.Find("projectile").GetComponent<ProjectileBehaviour>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            print("Fire");
            // fire projectile
            if (!pB.IsFiring()) {
                pB.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
