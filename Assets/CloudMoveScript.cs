using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour {
    public float moveSpeed = 1.5f;
    private float deadZone = -30;
    private float topZone = 7;
    private float spaceBetweenClouds = 2;

    // Start is called before the first frame update
    void Start() {
        // start with random position.y
        moveSpeed = Random.Range(1.4f, 2);
        spaceBetweenClouds = Random.Range(2.0f, 3.0f);
        transform.position = new Vector3(transform.position.x + (spaceBetweenClouds), Random.Range(-topZone, topZone), transform.position.z);
    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone) {
            Destroy(gameObject);
            Debug.Log("Cloud Destroyed");
        }
    }
}
