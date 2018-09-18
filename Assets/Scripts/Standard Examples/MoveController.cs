using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Класс перемещения по стрелкам клавиатуры с использованием компонента Rigidbody
public class MoveController : MonoBehaviour {
        
    Rigidbody rig; // переменная для хранения данных компонента
    public float speed = 10f; // публичное свойство скорости, задаваемое через редактор

	void Start () {
        rig = GetComponent<Rigidbody>(); // запись в переменную данных компонента
	}
		
	void Update () {
        Move(); //вызов метода Move, содержащего инструкции по перемещению 
	}

    void Move () // метод, содержащий инструкции перемещения
    {
        float moveForward = Input.GetAxis("Vertical")*speed; // переменная, значение которой рассчитывается при нажатии клавиш вперёд/назад или w/s.
        float moveHorizontal = Input.GetAxis("Horizontal")*speed; // переменная, значение которой рассчитывается при нажатии клавиш влево/вправо или a/d.

        Vector3 move = new Vector3(moveHorizontal, 0, moveForward); // переменная для хранения комплексного значения x,y,z всех рассчитанных переменных

        rig.AddForce(move); // передвижение методом AddForce компонента Rigidbody с использованием значения переменной Move.
    }
}
