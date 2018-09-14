using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для вывода информации о количестве нажатий на объекте
public class ColiiderInteractive : MonoBehaviour {
    
    int clickCount; // переменная для хранения информации о количестве нажатий

    private void OnMouseDown() // метод для определения нажатия мыши на объекте с коллайдером
    {        
        clickCount++; // увеличение переменной на единицу
    }

    private void OnGUI() // метод для отрисовки элементов меню
    {
        if (clickCount > 0) // если количество нажатий больше нуля
        {
            Rect rect = new Rect(10, 10, 50, 50); // подготавливаем новую прямоугольную область с координатами 10,10, длиной и шириной 50,50
            GUI.TextField(rect, clickCount.ToString()); // создаём текстовое поле с подготовленной прямоугольной областью и данными о количестве нажатий
        }
        
    }
}
