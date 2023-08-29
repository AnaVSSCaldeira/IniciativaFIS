using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionsAndAnswers : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public Button btnA;
    public Button btnB;
    public Button btnC;
    public Button btnD;

    public Button answerOne;
    public Button answerTwo;
    public Button answerThree;

    public Image feedback;
    public GameObject qA;
    public GameObject finalGame;

    public int questionNumber = 1;

    public static QuestionsAndAnswers instance;

    void Start()
    {
        ChangeQuestions();
        instance = this;
    }

    //void Update()
    //{

    //}
    public void Validation(Button answer)
    {
        //verifica qual � a quest�o!
        //1
        var feedbackGameObject = feedback.gameObject;
        feedbackGameObject.SetActive(true);
        Time.timeScale = 0;
        feedbackGameObject.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Voc� acertou!";
        if (questionNumber == 1)
        {
            if (answerOne == answer)
            {
                GameManager.instance.point += 1;
            }
            else
            {
                feedbackGameObject.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Voc� errou!<br>A resposta correta era:<br>Guardanapos de papel usados";
            }
        }
        //2
        else if (questionNumber == 2)
        {
            if (answerTwo.Equals(answer))
            {
                GameManager.instance.point += 1;
            }
            else
            {
                feedbackGameObject.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Voc� errou!<br>A resposta correta era:<br>Separar materiais recicl�veis do lixo comum";
            }
        }
        //3
        else if (questionNumber == 3)
        {
            if (answerThree.Equals(answer))
            {
                GameManager.instance.point += 1;
            }
            else
            {
                feedbackGameObject.GetComponentInChildren<Image>().gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Voc� errou!<br>A resposta correta era:<br>Economia de recursos naturais";
            }
        }
        questionNumber += 1;
    }

    public void ChangeQuestions()
    {
        print(questionNumber);
        feedback.gameObject.SetActive(false);
        Time.timeScale = 1;
        
        if (questionNumber == 1)
        {
            questionText.text = "Qual dos seguintes materiais <b>N�O</b> � geralmente recicl�vel?";
            btnA.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Papel";
            btnB.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Pl�stico";
            btnC.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Vidro";
            btnD.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Guardanapos de papel usados";
        }
        else if(questionNumber == 2)
        {
            questionText.text = "O que significa o termo 'coleta seletiva'?";
            btnA.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Coletar lixo apenas em dias espec�ficos";
            btnB.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Separar materiais recicl�veis do lixo comum";
            btnC.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Descartar todos os tipos de lixo no mesmo local";
            btnD.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Compartilhar objetos pessoais com os vizinhos";
            GameManager.instance.timer = 0f;
            GameManager.instance.totalSecond = 25f;
            GameManager.instance.second = 1f;
        }
        else if(questionNumber == 3)
        {
            questionText.text = "Qual � o benef�cio principal da reciclagem para o meio ambiente?";
            btnA.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Aumento da polui��o";
            btnB.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Economia de recursos naturais";
            btnC.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Redu��o da conscientiza��o ambiental";
            btnD.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Aumento das emiss�es de gases de efeito estufa";
            GameManager.instance.timer = 0f;
            GameManager.instance.totalSecond = 25f;
            GameManager.instance.second = 1f;
        }
        else if (questionNumber == 4)
        {
            Time.timeScale = 0;
            qA.SetActive(false);
            finalGame.SetActive(true);
            GameManager.instance.timerText.gameObject.SetActive(false);
            if (GameManager.instance.point == 3)
            {
                finalGame.GetComponentInChildren<TextMeshProUGUI>().text = "Parab�ns!";
            }
            else if (GameManager.instance.point == 2)
            {
                finalGame.GetComponentInChildren<TextMeshProUGUI>().text = "Quase!";
            }
            else if (GameManager.instance.point == 1)
            {
                finalGame.GetComponentInChildren<TextMeshProUGUI>().text = "Puxa!";
            }
            else if (GameManager.instance.point == 0)
            {
                finalGame.GetComponentInChildren<TextMeshProUGUI>().text = "Mais sorte na pr�xima!";
            }
            finalGame.GetComponentInChildren<TextMeshProUGUI>().text = finalGame.GetComponentInChildren<TextMeshProUGUI>().text+" Voc� acertou "+(GameManager.instance.point).ToString()+ " de 3 perguntas!";
            //trocar o X pelo questionNumber!!!
        }
    }
}
