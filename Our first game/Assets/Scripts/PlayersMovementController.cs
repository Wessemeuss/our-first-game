using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovementController : MonoBehaviour {

	public float PlayerSpeed = 200f; // Скорость персонажа
	private Rigidbody2D _playerRigidbody2D; // Элемент Rigidbody2D нужен для обработки физики

	void Start()
	{
		_playerRigidbody2D = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
	}
	
	void FixedUpdate () 
	{
		var horizontal = Input.GetAxis("Horizontal"); // Получаем значение по оси X
		var vertical = Input.GetAxis("Vertical"); // Получаем значение по оси Y
		// Выставляем скорость объекта на основе значения осей, скорости и времени, прошедшего с последнего кадра
		_playerRigidbody2D.velocity = new Vector2 (horizontal * PlayerSpeed * Time.deltaTime, vertical * PlayerSpeed * Time.deltaTime);
	}
}
