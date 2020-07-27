using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    Vector3 speedY = new Vector3(0.0f, 3.0f, 0.0f);
    float desplY = 23.04f;
    bool started = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started) {
            //speed Y
            transform.position = transform.position + speedY * Time.deltaTime;
            //desplY
            if(transform.position.y >= 11.52f) transform.position = transform.position - new Vector3(0.0f,1.0f,0.0f) * desplY;
        }
        
    }

    public void stopMovement() {
        started = false;
    }
}
