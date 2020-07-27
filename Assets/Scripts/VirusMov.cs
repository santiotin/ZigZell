using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMov : MonoBehaviour
{
    public Camera camera;
    Vector3 speedY = new Vector3(0.0f, 3.0f, 0.0f);
    Vector3 speedX = new Vector3(0.7f, 0.0f, 0.0f);
    float desplY = 30.0f;
    Vector3 iniPos;
    bool started = false;
    float dir;
    float desplX;
    float cameraWith;
    float cameraHeight;

    GameObject palos;
    GameObject baseR;
    GameObject baseL;
    // Start is called before the first frame update
    void Start()
    {
        started = false;

        //camera
        cameraHeight = 2f * camera.orthographicSize;
        cameraWith = cameraHeight * camera.aspect;
        baseL = this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        baseR = this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
        baseR.transform.position = new Vector3((cameraWith/2)-0.35f, baseR.transform.position.y, 0);
        baseL.transform.position = new Vector3(-(cameraWith/2)+0.35f, baseL.transform.position.y, 0);

        //desplX
        desplX = Random.Range(0f, 1.2f);
        palos = this.gameObject.transform.GetChild(0).gameObject;
        palos.transform.position = new Vector3(transform.position.x + desplX, transform.position.y, transform.position.z);

        //dir
        float aux = Random.Range(-1.0f,1.0f);
        if(aux >= 0) dir = 1.0f;
        else dir = -1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(started) {
            //speed Y
            transform.position = transform.position + speedY * Time.deltaTime;

            //speedX
            //palos.transform.position = palos.transform.position + speedX * dir * Time.deltaTime;
            //if(palos.transform.position.x <= 0) dir = 1.0f;
            //else if(palos.transform.position.x >= 1.2) dir = -1.0f;

            //desplY
            if(transform.position.y >= 10.0f) transform.position = transform.position - new Vector3(0.0f,1.0f,0.0f) * desplY;

        }
    }

    public void startMovement() {
        started = true;
    }

    public void stopMovement() {
        started = false;
    }
}
