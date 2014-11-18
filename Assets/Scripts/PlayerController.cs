﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Player player;
	private Sword sword;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player").GetComponent<Player>();
		sword = GameObject.Find ("Sword").GetComponent<Sword> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		int x = (int)Input.GetAxisRaw("Horizontal");
		int y = (int)Input.GetAxisRaw("Vertical");
		
		move(x, y);
		aim ();
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			sword.Swing ();
		}

	}

	void move(int x, int y)
	{
		float displace = player.speed * Time.deltaTime;
		float xComp = x * displace;
		float yComp = y * displace;

		if(x != 0 && y != 0)
		{
			xComp = xComp * Mathf.Sqrt(2)/2;
			yComp = yComp * Mathf.Sqrt(2)/2;

		}

		Vector3 velocity = new Vector3(xComp,yComp,0);
		this.gameObject.transform.Translate(velocity);
	}

	void aim()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Debug.Log (mousePos.x + " " + mousePos.y);
		Vector3 lookPos = new Vector3 (mousePos.x-this.transform.position.x, mousePos.y-this.transform.position.y, 0);
		this.transform.right = lookPos;

	}
}
