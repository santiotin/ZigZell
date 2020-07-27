using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public GameManager gameManager;
    public Camera camera;
    public AudioSource explode;
    public AudioSource point;
    public AudioSource touch;
    Vector3 speedY = new Vector3(0.0f, 3.5f, 0.0f);
    Vector3 rotationZ = new Vector3(0.0f, 0.0f, 400.0f);
    Vector3 iniSpeed = new Vector3(3.0f, 0.0f, 0.0f);
    Vector3 speed;
    Vector3 speedX = new Vector3(1.0f, 0.0f, 0.0f);
    float acc = 1.04f;
    float dir = 1.0f;
    float cameraWith;
    float cameraHeight;
    bool started = false;
    bool dead = false;
    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        speed = iniSpeed;
        cameraHeight = 2f * camera.orthographicSize;
        cameraWith = cameraHeight * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(started && !dead) {
            transform.Rotate( rotationZ * Time.deltaTime * -dir, Space.Self);

            transform.position = transform.position + speed * dir * Time.deltaTime;
            speed = speed * acc;

            if(Input.GetKeyDown("space") || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                touch.Play();
                dir = dir * -1.0f;
                speed = iniSpeed;
            }

            if(transform.position.x >= ((cameraWith/2)-0.7)) {
                touch.Play();
                dir = -1.0f;
                speed = iniSpeed;
            } else if(transform.position.x <= -((cameraWith/2)-0.7)) {
                touch.Play();
                dir = 1.0f;
                speed = iniSpeed;
            }
        } else if (started && dead) {
            gameManager.GetComponent<GameManager>().deadPlayer();
        }
    }

    public void startMovement() {
        started = true;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Vt" && !dead) {
            point.Play();
            gameManager.GetComponent<GameManager>().incrementPoints();
        }

        if (collider.tag == "Palo" && !dead) {
            dead = true;
            particleSystem.Emit(100);
            explode.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            gameManager.GetComponent<GameManager>().deadPlayer();
        }
    }
}
