using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject scoreText;
    public GameObject endMenu;
    public GameObject dieBackground;
    public GameObject lastBackground;
    public GameObject scoreTextFinal;
    public GameObject highscoreText;
    public GameObject bannerTop;
    public GameObject bannerBottom;
    public AudioSource audioButton;
    public GameObject[] viruses;
    public GameObject[] borders;
    public GameObject[] backGrounds;
    
    bool firstLoad = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            player.GetComponent<PlayerMov>().startMovement();
            for(int i = 0; i < viruses.Length; i++) {
                viruses[i].GetComponent<VirusMov>().startMovement();
            }
        }
    }

    public void deadPlayer() {
        for(int i = 0; i < viruses.Length; i++) {
            viruses[i].GetComponent<VirusMov>().stopMovement();
        }
        for(int i = 0; i < borders.Length; i++) {
            borders[i].GetComponent<BorderMov>().stopMovement();
        }
        for(int i = 0; i < backGrounds.Length; i++) {
            backGrounds[i].GetComponent<BackgroundMove>().stopMovement();
        }
        StartCoroutine(waitToFade());
        if(firstLoad) {
            bannerTop.GetComponent<Banner>().RequestBanner();
            bannerBottom.GetComponent<Banner>().RequestBanner();
            firstLoad = false;
        }
    }

    public void incrementPoints() {
        scoreText.GetComponent<ScoreText>().incrementPoints();
    }

    IEnumerator waitToFade() {
        yield return new WaitForSeconds(0.3f);

        float score = scoreText.GetComponent<ScoreText>().getPoints();
        float highscore = PlayerPrefs.GetFloat("highscore", 0);

        if(score > highscore) {
            PlayerPrefs.SetFloat("highscore", score);
            highscore = score;
        }

        scoreTextFinal.GetComponent<Text>().text = score.ToString();
        highscoreText.GetComponent<Text>().text = string.Concat("Highscore: ", highscore.ToString());

        dieBackground.SetActive(true);
        endMenu.SetActive(true);
    }

    public void retry() {
        bannerTop.GetComponent<Banner>().OnDestroy();
        bannerBottom.GetComponent<Banner>().OnDestroy();
        firstLoad = true;
        audioButton.Play();
        lastBackground.SetActive(true);
        StartCoroutine(changeScene(1));
    }

    public void goToMenu() {
        audioButton.Play();
        lastBackground.SetActive(true);
        StartCoroutine(changeScene(0));
    }

    IEnumerator changeScene(int sceneNum) {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneNum);
    }
}
