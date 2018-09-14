using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // пространство имён для использования класса NavMeshAgent

// Класс для создания агента патрулирования по заданным точкам
public class NavigatorControl : MonoBehaviour {

    public Transform[] NavPoints; // массив для хранения координат точек обхода
    NavMeshAgent agent; // переменная для хранения данных компонента
    int i; // переменная для отслеживания количества посещённых точек и последовательного переключения
	
	void Start () {
        agent = GetComponent<NavMeshAgent>(); // запись в переменную данных компонента        
        i = 0; // присвоение изначального значения 0 (индекс первого элемента в массиве)
	}
		
	void Update () {
                
        if (i < 3) // если агент обошёл меньше четырёх точек (поскольку массив начинается с нуля, то число точек = 0,1,2,3)
        {
            agent.SetDestination(NavPoints[i].position); // используем метод SetDestination класс NavMeshAgent для перемещения к позиции объекта с порядковым номером i в массиве
            if (Vector3.Distance(transform.position, NavPoints[i].position) < 1.0f) i++; // используем метод Distance структуры Vector3 для определения расстояния между текущей позицией
                                                                                         // и позицией цели. Если дистанция меньше единицы, то прибавляем i+1. Таким образом,
                                                                                         // переключаем на позицию нового объекта в массиве
        }
        else // если агент обошёл три точки
        {
            agent.SetDestination(NavPoints[i].position); // идём к последней точке
            if (Vector3.Distance(transform.position, NavPoints[i].position) < 1.0f) i=0; //если дистанция меньше 1, то сбрасываем значение i на ноль, 
                                                                                         //тем самым возвращая к началу списка объектов в массиве
        }                
	}
}
