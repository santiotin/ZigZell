using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeBackground;
    public AudioSource btnPress;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1")) {
            playGame();
        }
    }

    public void playGame() {
        btnPress.Play();
        fadeBackground.SetActive(true);
        StartCoroutine(changeScene(1));
    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(sceneNum);
    }

    
}
