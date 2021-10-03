using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigid;
    public float speed;
    int score = 0;
    public Text scoreText;
    public Text timeText;
    public Text warningText;
    Vector3 Fark;
    public GameObject Camera;
    Vector3 Sumx;
    Vector3 Sumy;
    float time;
    int counter;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Fark = Camera.transform.position - transform.position;
        warningText.text = "GO GO GO";
    }

    void Update()
    {
        #region Score
        CarMovement();
        scoreText.text = "SCORE: " + score.ToString();
        #endregion

        #region Time
        GameTime();
        timeText.text = "TIME: " + counter;

        if (counter == 1)
        {
            warningText.gameObject.SetActive(false);
        }
        #endregion

        #region Camera
        Sumx = transform.position + Fark;
        Sumy = transform.position + Fark;

        Camera.transform.position = new Vector3(Sumx.x , Sumy.y , Camera.transform.position.z);
        #endregion
    }

    void CarMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector3(horizontal * speed, 0, 0));
    }

    void GameTime()
    {
        time += Time.deltaTime;

        if (time > 1)
        {
            counter++;
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Finish")
        {
            warningText.gameObject.SetActive(true);
            warningText.text = "GAME OVER!!!";
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
    }
}
