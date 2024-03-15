using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessions = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    // Start is called before the first frame update
    void Start()
    {
        //Esta linea hace que compruebe si la variable lessonContainer no es nula, si lessonContainer es diferente de null, es que ya se agrego al Inspector en unity

      if (lessonContainer != null)
        {
            // Este metodo es el encargado de actualizar la interfaz del usuario en la leccion.
            OnUpdateUI();
        }
        else
        {
            //Este manda un mensaje de advertencia por Debug.LogWarning, para indicar que hay un GameObject nulo.
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo GameObject lessonContainer");
        }
    }

    // Con este metodo actualizaremos la UI, actualizara el texto en el menu que indica la leccion.
    public void OnUpdateUI()
    {
        //En esta linea se comprobara si el objeto StageTitle o LessonStage no sean nulos.
        if (StageTitle != null || LessonStage != null)
        {
           //Aqui se actualizara el texto con el arreglo para indicar la leccion.
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessions;
        }
        else
        {
            //  En esta linea se mandara un mensaje de aviso si no se ha asignado los objetos en sus slots correspondientes.
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo TMP_Text");
        }
    }



    // Este metodo activa/desactiva la ventana de lessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();
        if (lessonContainer.activeSelf)
        {
            //Desactiva el objecto si esta activo
            lessonContainer.SetActive(false);
        }
        else
        {
            //Activa el objecto si esta desactivado
            lessonContainer.SetActive(true);
        }
    }
}
