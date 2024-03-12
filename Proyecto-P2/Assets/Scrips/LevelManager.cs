using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Data")]
    public Subject Lesson;

    [Header("User Interface")]
    public TMP_Text questionGood;
    public TMP_Text QuestionTxt;
    public List<Option> Options;
    public GameObject checkButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red; 

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;

    [Header("Current Lesson")]
    public Leccion currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }



    void Start()
    {
        //Establecemos la cantidad de preguntas en la leccion
        questionAmount = Lesson.leccionList.Count;
        LoadQuestion();
        
    }


    private void LoadQuestion()
    {

        //Asegurarnos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            //Establecemos la leccion actual
            currentLesson = Lesson.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = currentLesson.lessons;
            //Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Establecemos la pregunta en UI
            QuestionTxt.text = question;
            // Establecemos las Opciones
            for (int  i= 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<Option>().OptionId = i;
                Options[i].GetComponent<Option>().UpdateText();
            }
            
        }
        else
        {
            //Si llegamos al final de las preguntas.
            Debug.Log("Fin de las preguntas");
        }
    }

    public void NextQuestion()
    {
        if (CheckPlayerState())
        {
            //Asegurarnos que la pregunta actual este dentro de los limites
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    questionGood.text = ("Respuesta Correcta. " + question + ";" + correctAnswer);

                }
                else
                {
                    AnswerContainer.GetComponent<Image>().color = Red;
                    questionGood.text = ("Respuesta Incorrecta. " + question + ";" + correctAnswer);
                }
                //Incrementamos el indice de la pregunta actual
                currentQuestion++;
                //Mostrar el resultado durante un tiempo (Puedes usar una coroutine o Invoke)
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
                //Reset answer from player
                answerFromPlayer = 9;
            }


            else
            {
                //Cambio de escena
            }
        }
    }

    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajustar el tiempo que deseas mostrar el resultado
        yield return new WaitForSeconds(2.5f);

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Carga la nueva pregunta
        LoadQuestion();

        CheckPlayerState();

    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    public bool CheckPlayerState()
    {
        if (answerFromPlayer != 9)
        {
            checkButton.GetComponent<Button>().interactable = true;
            checkButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            checkButton.GetComponent<Button>().interactable = false;
            checkButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
}


