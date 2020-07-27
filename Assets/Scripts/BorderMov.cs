using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMov : MonoBehaviour
{
    public Camera camera;
    public bool side;
    Vector3 speed = new Vector3(0.0f, 3.0f, 0.0f);
    Vector3 desplY = new Vector3(0.0f, -19.1f, 0.0f);
    float cameraWith;
    float cameraHeight;

    bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        float borderWith = GetComponent<Collider2D>().bounds.size.x;

        cameraHeight = 2f * camera.orthographicSize;
        cameraWith = cameraHeight * camera.aspect;
        if(side) transform.position = new Vector3((cameraWith/2)-(borderWith/2), transform.position.y, 0);
        else transform.position = new Vector3(-(cameraWith/2)+(borderWith/2), transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(move) {
            transform.position = transform.position + speed * Time.deltaTime;

            if(transform.position.y >= 7.32f) transform.position = transform.position + desplY;
        }
        
    }

    public void stopMovement() {
        move = false;
    }
}
