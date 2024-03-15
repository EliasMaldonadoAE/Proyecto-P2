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

   //Aqui se garantiza que una clase solo tenga una instancia y un solo punto de acceso a ella.
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
                //En esta linea internaremos la lista de opciones y actualizar las propiedades de los componentes Option que adjunta a los objetos Question          
                //Aqui se aplica cada Question para que tenga un componente option al que se puede acceder
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                //OptionID se puede usar para identificar cada opcion de manera unica.
                Options[i].GetComponent<Option>().OptionId = i;
                //Aqui se actualiza el texto que se mostrara en el componente Option que se basara en la opcion seleccionada.
                Options[i].GetComponent<Option>().UpdateText();
            }
            
        }
        else
        {
            //Si lo cumplen las reglas anteriores se mandara el mensaje siguente:
            //Si llegamos al final de las preguntas.
            Debug.Log("Fin de las preguntas");
        }
    }

   //Funcion que nos manda a la siguiente pregunta
    public void NextQuestion()
    {
        //Checa la respuesta seleccionada del jugador
        if (CheckPlayerState())
        {
            //Asegurarnos que la pregunta actual este dentro de los limites
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                //Se revisa si la respuesta es correcta
                if (isCorrect)
                {
                    //Si la respuesta es correcta, se actualizara el Image y se pondra en color verde para referenciar la respuesta correcta.
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //Se actualizara el componente texto y se mostrara el mensaje que querramos mostrar.
                    questionGood.text = ("Respuesta Correcta. " + question + ";" + correctAnswer);

                }
                else
                {
                    // //Si la respuesta es INCORRECTA, se actualizara el Image y se pondra en color rojo para referenciar la respuesta incorrecta.
                    AnswerContainer.GetComponent<Image>().color = Red;
                    //Se actualizara el componente texto y se mostrara el mensaje que querramos mostrar.
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

    //Iniciara una corrutina en la cual se suspendera el codigo por el tiempo que se quiera.
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajustar el tiempo que deseas mostrar el resultado
        yield return new WaitForSeconds(2.5f);

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Carga la nueva pregunta
        LoadQuestion();

       //Esta es la funcion para poder checar si hay una opcion seleccionada
        CheckPlayerState();

    }

   // Funcion donde se asignara la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
        //Esta linea actualizara la respuesta del jugador con el valor proporcionado como argumento de la funcion.
        answerFromPlayer = _answer;
    }

    //Funcion que revisara si el jugador esta interactuando con un boton para cambiar el color de los botones y activarlos.
    public bool CheckPlayerState()
    {
       // Checa que al interactuar con los botones, estos cambien de color al ser seleccionados
        if (answerFromPlayer != 9)
        {
            //Si  no se llega a interactuar con el boton, se pondra de color gris para indicar que se interactue con el.
            //Se actualiza el componente Button para hacer que se pueda usar.
            checkButton.GetComponent<Button>().interactable = true;
            //Se actualiza el componente Image para cambiar su color.
            checkButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            //Si no se interactua con el boton se pondra blanco, asi dando a saber que ya no se puede usar.
            //Se actualizara el componente Button para hacer que ya no se pueda usar.
            checkButton.GetComponent<Button>().interactable = false;
            //Se actualizara el componente Image para cambiar su color
            checkButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }
}


