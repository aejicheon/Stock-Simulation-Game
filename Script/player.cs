using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    bool isJump = false;
    bool isTop = false;
    public float jumpH = 0;
    public float jumpSpeed = 0;
    public Text scoreText;
    public int score = 0;
    public Text timeText;

    public AudioClip coinsound;
    private AudioSource backsound;
    public AudioClip oversound;
    

    Vector2 startPosition;
    Animator animator;
    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        timeText.text = "���� �ð� : " + 0 + "��";
        scoreText.text = "ȹ�� �ݾ� : " + 0 + "��";

        backsound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0) // Only update time if the game is not paused
        {
            float remainingTime = Mathf.Round(60 - Time.time);
            timeText.text = "���� �ð� : " + remainingTime + "��"; // 60 - Time.time�� ����Ͽ� 60�ʺ��� ���ҽ�Ŵ

            // �ð��� 0�� �Ǹ� Game Over ������ ��ȯ
            if (remainingTime <= 0)
            {
                GameOver();
            }
        }

        animator.SetBool("run", true);

        if (Input.GetMouseButtonDown(0))
        {
            isJump = true;
        }
        else if (transform.position.y <= startPosition.y)
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }
        if (isJump)
        {
            if (transform.position.y <= jumpH - 0.1f && !isTop)
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpH), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }
            if (transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
            }
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        backsound.PlayOneShot(oversound);
        SceneManager.LoadScene("GameOver");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("�浹��");
            Time.timeScale = 0;
            backsound.PlayOneShot(oversound);
            SceneManager.LoadScene("GameOver");
        }

        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("�浹��");
            other.gameObject.SetActive(false);
            ScoreUp(1000);
            backsound.PlayOneShot(coinsound);
        }
    }
    public void ScoreUp(int scoreValue)
    {
        score += scoreValue;
        
        scoreText.text = "ȹ�� �ݾ� : " + score + "��";

        PlayerPrefs.SetInt("TotalScore", score);
    }
}