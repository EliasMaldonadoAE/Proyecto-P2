using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new Subject", menuName = "ScriptableObjects/NewLesson", order = 1)]
public class Subject : ScriptableObject
{
    //Scripteable Object que servira para poder crear una leccion, en la cual se heredaran informacion y puede ser la alternativa sin tener que mover el codigo principal en este mismo.
    //Codigo de herencia.
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header ("Lession Quest Configuration")]
    public List<Leccion> leccionList; 
}
