using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour 
{
	[Header("Objects")]
	public Snake snake;
	public GameController controller;

	[Header("Floats")]
	public float min;
	public float max;
	public float dist;

	void Update () 
	{
		//Distancia de cabeza del Snake < 1
		// --> SI --> snake.AddPiece() --> se pondra en una posición aleatoria [Random.Range (int min, int max)]
		//int min e int max deben estar dentro de los límites de GameController;

		dist = Vector3.Distance (this.transform.position, snake.head.position);

		if (dist < 1.0f) 
		{
			Debug.Log ("Ñam");
			snake.AddPiece();

			this.Position ();
		}
	}

	void Position()
	{
		this.transform.Translate (new Vector3 (Random.Range (min, max), 0f, Random.Range (min, max)));

		if (this.transform.position.x >= 9.5f || this.transform.position.x <= -9.5f || this.transform.position.z >= 9.5f || this.transform.position.z <= -9.5f) 
		{
			Debug.Log ("Estoy fuera JA JAAA");
			this.transform.position = new Vector3 (0.0f, 0.5f, 0.0f);
		}

		//SNAKE VELOCIDAD
		snake.speed -= 0.05f;

		if (snake.speed <= 0.1f) snake.speed = 0.1f;
	}
}