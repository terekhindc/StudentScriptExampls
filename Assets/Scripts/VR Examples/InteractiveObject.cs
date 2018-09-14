// Класс интерактивного взаимодействия с контроллерами HTC Vive
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem; // пространство имён для доступа к классам SteamVR

[RequireComponent(typeof(Interactable))] // указатель на обязательный компонент Interactable, который появится автоматически в инспекторе вместе с добавлением скрипта
public class InteractiveObject : MonoBehaviour
{

    Material material; // переменная для хранения данных о материале

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material; // запись в переменную данных с компонента
        material.color = Color.black; // назначение изначального чёрного цвета материалу
    }

    void HandHoverUpdate(Hand hand) // метод, аналогичный Update, отслеживающий с каждым кадром взаимодействие контроллера (Hand) с объектом
    {
        if (hand.GetStandardInteractionButtonDown()) // метод GetStandardInteractionButtonDown() класса Hand проверяет нажатие основной клавиши на контроллере или мыши 
        {
            if (hand.currentAttachedObject != gameObject) // проверяем наличие объекта в руке с помощью свойства currentAttachedObject класса Hand. 
                                                          // Если объект не является текущим объектом, то
            {
                hand.AttachObject(gameObject); // с помощью метода AtachObject класса Hand добавляем в руку текущий объект
                hand.HoverLock(GetComponent<Interactable>()); // с помощью метода HoverLock класса Hand ограничиваем возможность добавить другие объекты
                material.color = Color.red; // меняем цвет материала взятого объекта на красный
            }
            else
            {
                hand.DetachObject(gameObject); // с помощью метода DetachObject открепляем текущий объект от контроллера
                hand.HoverUnlock(GetComponent<Interactable>()); // разблокируем возможность взять объект
                material.color = Color.black; // меняем цвет материала снова на чёрный
            }
        }
    }
}
