using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для рандомного изменения цвета объекта при нажатии клавиши "C"
public class ChangeColorMaterial : MonoBehaviour {

    Material mat; // переменная для хранения информации о материале

	void Start () {
        mat = GetComponent<MeshRenderer>().material; // записываем в переменную данные со свойства material компонента MeshRenderer
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.C)) // если нажата клавиша "C"
        {
            // создаём переменные типа byte для каждого канала цвета RGB и задаём для них рандомное значение от 0 до 255
            // в скобочках указываем (byte) для явного приведения типа получаемого значения 
            //(иначе Random.Range нам вернёт значение типа int и получится ошибка            
            byte r = (byte)Random.Range(0, 255);
            byte g = (byte)Random.Range(0, 255);
            byte b = (byte)Random.Range(0, 255);            

            mat.color = new Color32(r, g, b,255); //используем свойство color материала и задаём новый цвет
        }
	}
}
