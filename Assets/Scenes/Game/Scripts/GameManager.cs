using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int point = 0;

    public TextMeshProUGUI pointsCount;
    public TextMeshProUGUI timerText;

    public float timer = 0f;
    public float totalSecond;
    public float second = 1f;
    void Start()
    {
        instance = this;
        pointsCount.text = point.ToString() + "/3";
        totalSecond = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        pointsCount.text = point.ToString() + "/3";
        if (second > 0)
        {
            DecreaseTimer();
            if (second <= 5)
            {
                timerText.color = new Color32(238, 8, 20, 255);
            }
            else
            {
                timerText.color = new Color32(0, 0, 0, 255);
            }
            if(second == 0)
            {
                QuestionsAndAnswers.instance.questionNumber += 1;
                QuestionsAndAnswers.instance.feedback.gameObject.SetActive(true);
                QuestionsAndAnswers.instance.feedback.gameObject.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Acabou o tempo<br>Mais sorte na próxima!";
            }
        }
    }

    public void DecreaseTimer()
    {
        timer += Time.deltaTime;
        second = totalSecond - Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", 0, second);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
