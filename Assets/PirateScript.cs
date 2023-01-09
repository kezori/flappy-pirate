using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PirateScript : MonoBehaviour {
    public Rigidbody2D PirateRigidBody;
    public float highJump = 10;
    public LogicScript logic;
    public AudioSource pirateJumpSound;
    public bool gameOver = false;
    public float TopDeathZone = 9.43f;
    public float BottomDeathZone = -9;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update() {
        if (gameOver == false) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                PirateRigidBody.velocity = Vector2.up * highJump;
                pirateJumpSound.Play();
            }
            if (transform.position.y > TopDeathZone || transform.position.y < BottomDeathZone) {
                gameOver = true;
                logic.gameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
    }
}
