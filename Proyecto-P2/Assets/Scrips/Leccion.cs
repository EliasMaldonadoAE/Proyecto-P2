using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Linea de codigo que se usara paran poder trabajar con los prefabs.   
[System.Serializable]
    public class Leccion
    {
       //Variables que se usaran en los demas Scripts que aydaran a asignar las respuestas
        public int ID;
        public string lessons;
        public List<string> options;
        public int correctAnswer;
    }

