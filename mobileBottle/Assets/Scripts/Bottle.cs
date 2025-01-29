using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottle : MonoBehaviour
{
    public Transform bottleTwo;
    public TextMeshProUGUI healthText, endText;
    public static int health = 3;
    [SerializeField] private GameObject endPanel;
    public bool gameStart = false;
    public bool gameEnd = true;
    public AudioSource breaking;
    public Button button;
    public Rigidbody2D bottleRb;
    void Update()
    {
        healthText.text = "" + health;
        if (health <= 0 && gameStart && !gameEnd)
        {
            gameEnd = true;
            health = 0;
            endText.text = "Game Over!";
            endPanel.SetActive(true);
            Debug.Log("gameBitti");
            Time.timeScale = 0;

            //if (Input.anyKeyDown) {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  Time.timeScale = 1;}

        }
        /*if (!gameStart)
        {
            transform.position = new Vector3(bottleTwo.transform.position.x, transform.position.y, transform.position.z);
        }*/

        if (Input.GetMouseButtonDown(0) && !gameStart)
        {
            gameStart = true;
            gameEnd = false;
            Debug.Log("oyunStart");
            bottleRb.constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 10f);
        }
    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        float random=Random.Range(-2f, 2f);
        if (contact.gameObject.tag == "Ground")
        {
            bottleTwo.position = new Vector3(random, 6f, 0f);
            health--;
            breaking.Play();
        }
    }
}
