using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionId;
    public string OptionName;


   //Se usa el componente TMP del texto para poder acutalizarlo al texto que tiene una pregunta en el Scriptable Object,
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    //Funcion que actualizara el texto.
    public void UpdateText()
    {
        //Se obtiene el componente Children en el cual tiene el texto para actualizarlo a las listas del Scripteable Object.
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    //Funcion que checa si se selecciona una opcion y llama a dos funciones del script levelManager.
    public void SelectOption()
    {
        //Asigna la respuesta correcta en la funcion ID que se encuentra en el Script Subject
        LevelManager.Instance.SetPlayerAnswer(OptionId);
        //Comprueba con el Script levelManager si se selecciona una respuesta y cheque si los botones son interactuables.
        LevelManager.Instance.CheckPlayerState();
    }

}
