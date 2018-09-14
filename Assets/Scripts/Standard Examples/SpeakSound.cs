using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для воспроизведения звука при клике на объект
public class SpeakSound : MonoBehaviour {

    AudioSource audioPlayer; // переменная для записи данных с компонента AudioSource
    public AudioClip clip; // публичная переменная для добавления звука
	
	void Start () {
        audioPlayer = GetComponent<AudioSource>(); // запись в переменную данных с компонента
	}

    private void OnMouseDown() // метод, определяющий нажатие на объект, если на нём есть collider+rigidbody
    {
        audioPlayer.clip = clip; // добавление в аудиоплеер нового звука из переменной clip
        audioPlayer.Play(); // использование метода Play() класса AudioClip для проигрывания звука
    }
}
