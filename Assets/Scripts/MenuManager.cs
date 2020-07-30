using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MenuManager : MonoBehaviour
{
    public GameObject fadeBackground;
    public AudioSource btnPress;
    public GameObject highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        float highscore = PlayerPrefs.GetFloat("highscore", 0);
        highscoreText.GetComponent<Text>().text = string.Concat("Highscore: ", highscore.ToString());
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
