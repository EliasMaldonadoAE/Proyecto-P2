using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class LevelManager : MonoBehaviour
{
    [Header("Level Data")]
    public Subject Lesson;
    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public List<Option> Options;
    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string currentAnswer;
    [Header("Current Lesson")]
    public Leccion correctLesson;

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
            correctLesson = Lesson.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = correctLesson.lessons;
            //Establecemos la respuesta correcta
            currentAnswer = correctLesson.options[correctLesson.correctAnswer];
            //Establecemos la pregunta en UI
            QuestionTxt.text = question;
            
        }
        else
        {
            //Si llegamos al final de las preguntas.
            Debug.Log("Fin de las preguntas");
        }
    }

    public void NextQuestion()
    {
        //Asegurarnos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            //Incrementamos el indice de la pregunta actual
            currentQuestion++;
            //Cargar nueva pregunta
            LoadQuestion();
        }
        else
        {
            //Cambio de escena
        }
    }
}

