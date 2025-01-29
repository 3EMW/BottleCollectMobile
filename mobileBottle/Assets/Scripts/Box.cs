using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private float minXValue = -2f;
    [SerializeField] private float maxXValue = 2f;
    private GameObject bottle;
    public Transform bottle2;
    private int score,highScore;
    public TextMeshProUGUI scoreText,highScoreText;
    public AudioSource taking;

    void Start()
    {
        bottle = GameObject.Find("Bottle");
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
            highScoreText.text = "HighScore :" + highScore.ToString();
        }
    }

    void Update()
    {
        scoreText.text = "Your Score : " + score;
        Vector3 farePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        farePos.x = Mathf.Clamp(farePos.x, minXValue, maxXValue);
        base.transform.position = new Vector3(farePos.x, base.transform.position.y, base.transform.position.z);
        //transform.position = new Vector3(Top.transform.position.x, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        float random = Random.Range(-2f, 2f);
        if (contact.gameObject.tag == "Bottle")
        {
            bottle2.position = new Vector3(random, 6f, 0f);
            score += 5;
            taking.Play();


            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = "Highscore:" + highScore.ToString();
                PlayerPrefs.SetInt("Highscore", highScore);
            }
            else
            {
                //highScore = 0;
            }
        }
    }
}
