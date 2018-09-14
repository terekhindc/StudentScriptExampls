using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для изменения формы примитива через рандомное распределение точек полигональной сетки
public class ChangeMeshFilter : MonoBehaviour {

    MeshFilter meshFilter; // Создание свойства для записи данных компонента, отвечающего за полигональную сетку (данные о её точках, гранях и полигонах)
    bool originalForm = true; // Переменная для условия проверки смены формы или возврата к оригиналу
    Vector3 [] originalVertices; // Векторный массив для хранения координат точек оригинальной сетки

    void Start ()
    {
        meshFilter = GetComponent<MeshFilter>(); // стандартная форма инициализации свойства
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.F)) // проверка условия нажатия клавиши F
        {
            originalForm = !originalForm; // смена значения переменной на противоположное

            if (!originalForm) // если переменная в значениие false, то по инструкциям ниже сетка изменит позиции координат точек
            {
                originalVertices = meshFilter.mesh.vertices; // запись в массив векторных координат точек полигональной сетки для сохранения оригинального значения
                Vector3[] vertices = meshFilter.mesh.vertices; // запись в массив векторных координат точек полигональной сетки для дальнейших преобразований

                for (int i = 0; i < vertices.Length; i++) // цикл для перебора каждого элемента массива
                {
                    // рассчёт рандомной позиции каждой точки по x,y,z
                    float rndX = Random.Range(-0.2f, 0.2f);
                    float rndY = Random.Range(-0.2f, 0.2f);
                    float rndZ = Random.Range(-0.2f, 0.2f);

                    vertices[i] += new Vector3(rndX, rndY, rndZ); // добавление к текущим координатам точки в массиве данных о рандомном изменении позиции
                }

                meshFilter.mesh.vertices = vertices; // передача массива новых координат точек в компонент MeshFilter для перестройки
                meshFilter.mesh.RecalculateNormals(); // использование метода пересчёта нормалей для отображения света
            }
            else // иначе, если переменная originalForm в значении true, то по инструкциям ниже сетка восстановит оригинальные позиции координат точек
            {
                meshFilter.mesh.vertices = originalVertices; // передача массива оригинальных координат точек в компонент MeshFilter для перестройки
                meshFilter.mesh.RecalculateNormals(); // использование метода пересчёта нормалей для отображения света
            }            
        }
    }
        
}
