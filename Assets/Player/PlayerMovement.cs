using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Vector3 target;

    // Use this for initialization
    void Start() {
        target = transform.position;
    }

    // Update is called once per frame
    void Update() {

        //get click position
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            print(target);
        }

        if (!target.Equals(transform.position)) {
            //transform.Translate((target - transform.position) * speed * Time.deltaTime);
            transform.Translate((target - transform.position).normalized * PlayerValues.Speed * Time.deltaTime);
        }
    }
}