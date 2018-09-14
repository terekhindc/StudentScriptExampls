using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для вращения объекта с помощью мыши
public class ObjectMouseRotate : MonoBehaviour {
	
	void Update () {
        // запись в переменные данных о перемещении мыши по оси X и Y
        float MouseX = Input.GetAxis("Mouse X"); 
        float MouseY = Input.GetAxis("Mouse Y");

        // расчёт новой позиции вращения, как суммы старой позиции + данные о смещении мыши
        float rotX = transform.localEulerAngles.y + MouseX; 
        float rotY = transform.localEulerAngles.z + MouseY;

        //использование свойства localEulerAngles класса Transform для записи данных о новой позиции вращения на основании предыдущих расчётов
        transform.localEulerAngles = new Vector3(0, rotX, rotY);        
    }
}
