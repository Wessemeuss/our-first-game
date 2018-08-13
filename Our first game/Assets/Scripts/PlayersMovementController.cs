using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovementController : MonoBehaviour {

	public float PlayerSpeed = 200.0f; // Скорость персонажа
	Rigidbody2D playerRigidbody2D; // Элемент Rigidbody2D нужен для обработки физики

	void Start()
	{
		playerRigidbody2D = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
	}
	
	// Используем FixedUpdate для правильной обработки физики
	void FixedUpdate () 
	{
		Move();
		Rotate();
	}

	// Метод, отвечающий за перемещение персонажа
	void Move()
	{
		var horizontal = Input.GetAxis("Horizontal"); // Получаем значение по оси X
		var vertical = Input.GetAxis("Vertical"); // Получаем значение по оси Y
		// Выставляем скорость объекта на основе значения осей, скорости и времени, прошедшего с последнего кадра
		playerRigidbody2D.velocity = new Vector2 (horizontal * PlayerSpeed * Time.deltaTime, vertical * PlayerSpeed * Time.deltaTime);
	}

	// Метод, отвечающий за поворот персонажа в направление
	void Rotate()
	{
		var mousePosition = Input.mousePosition; // Получаем позицию мыши
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // Конвертируем позицию мыши в позицию в пространстве
		var direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y); // Определяем направление поворота
		transform.up = direction; // Поворачиваем объект
	}
}
