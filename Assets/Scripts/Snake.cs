using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour 
{
	[Header("Objects")]
	public Transform head;
	public GameController controller;

	[Header("Vectors")]
	public Vector3 direction;
	private Vector3 pos;

	[Header("Floats")]
	public float speed;
	private float _speed;

	List <SnakePiece> body = new List <SnakePiece>();

	void Start () 
	{
		_speed = speed;

		if (head) pos = transform.position;

		SnakePiece headPiece = new SnakePiece(true, head);
		body.Add (headPiece);

		Time.fixedDeltaTime = 0.05f;
	}

	void FixedUpdate () 
	{
		//MOVEMENT
		_speed -= Time.deltaTime;

		if (_speed <= 0f) 
		{
			this.Movement ();
			_speed = speed;
		}

		//IMPACT
		this.Impact();
	}

	public void AddPiece()
	{
		//Se crea un objeto de SnakePiece y se añadirá a la Lista body
		GameObject go = GameObject.CreatePrimitive (PrimitiveType.Cube);

		go.transform.position = body[body.Count-1].piece.position - direction;

		SnakePiece sp = new SnakePiece (go.transform);

		body.Add (sp);
	}

	public void Movement()
	{
		//Recorrer lista body desde el final hasta el principio 
		//llamando a NewPosition() de cada SnakePiece --> después avanzar 1m
		for (int i = body.Count - 1; i > 0; i--) 
		{
			body [i].NewPosition (body[i-1]);
		}

		if(head)
		{	
			pos += direction;
			this.transform.position = pos;
		}
	}
		
	public void Impact()
	{
		//Recorrer lista body llamando al método Collision en cada pieza
		//Y si Collision = true --> controller.GameoOver();
		foreach (SnakePiece i in body) 
		{
			if (i.Collision (head.position) == true)
			{
				Debug.Log ("Lo has intentado y HAS FRACASADO");
				controller.GameOver ();
			} 
			else Debug.Log ("Has tenido suerte... pero solo por esta vez");
		}
	}
}