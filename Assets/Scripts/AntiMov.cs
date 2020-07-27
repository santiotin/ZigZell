using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMov : MonoBehaviour
{

    Vector3 rotationZ = new Vector3(0.0f, 0.0f, 700.0f);
    Vector3 speedY = new Vector3(0.0f, 3.0f, 0.0f);
    Vector3 speedX = new Vector3(1.0f, 0.0f, 0.0f);
    Vector3 iniPosition;
    bool started = false;
    float dir = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        iniPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(started) {
            transform.Rotate( rotationZ * Time.deltaTime, Space.Self);
            transform.position = transform.position + speedY * Time.deltaTime;

            transform.position = transform.position + speedX * dir * Time.deltaTime;

            if(transform.position.x > (iniPosition.x + 0.5)) dir = -1.0f;
            else if(transform.position.x < (iniPosition.x - 0.5)) dir = 1.0f;
            
        }
        
    }

    public void startMovement() {
        started = true;
    }
}
