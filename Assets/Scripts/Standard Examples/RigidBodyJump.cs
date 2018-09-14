using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс прыжка по нажатию клавиши пробел
public class RigidBodyJump : MonoBehaviour {

    Rigidbody rig; // переменная для хранения данных компонента Rigidbody

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>(); // запись в переменную данных компонента
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) // если нажата клавиша пробел
        {
            rig.AddForce(0, 250, 0); // осуществляет прыжок объекта по оси Y
        }
	}
}
