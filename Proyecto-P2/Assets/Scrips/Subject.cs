using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Leccion
{
    public int ID;
    public string lessons;
    public List<string> opciones;
    public int correctAnswer;
}

[CreateAssetMenu(fileName = "new Subject", menuName = "ScriptableObjects/NewLesson", order = 1)]
public class Subject : ScriptableObject
{
    public List<Leccion> leccionList; 
}
