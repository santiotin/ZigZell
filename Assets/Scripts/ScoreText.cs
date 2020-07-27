using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    float points = 0.0f;
    public Camera camera;
    public Text scoreText;
    public float cameraHeight;
    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = 2f * camera.orthographicSize;
        //transform.position = new Vector3(transform.position.x, (cameraHeight - 20), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = points.ToString();
    }

    public void incrementPoints() {
        points++;
    }

    public float getPoints() {
        return points;
    }
}
