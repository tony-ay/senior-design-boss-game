using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Renderer rend;

    private Vector3 target;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        target = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (rend.enabled) {
            if (PlayerValues.Health <= 0) {
                rend.enabled = false;
            }
            else {
                //get click position
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = 0;
                }

                if (!target.Equals(transform.position)) {
                    //transform.Translate((target - transform.position) * speed * Time.deltaTime);
                    transform.Translate((target - transform.position).normalized * PlayerValues.Speed * Time.deltaTime * PlayerValues.debuffMod);
                }
            }
        }
    }
}