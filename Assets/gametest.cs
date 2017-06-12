using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gametest : MonoBehaviour {

	public GameObject ball1,ball2,ball3;
	GameObject g;
	public float speed;
	float x,y,z,time=10f;
	Vector3 pos;
	int count=0;
	int rc=0,gc=0,bc=0;
	void Start () {
		//ball = new GameObject[3];
		InvokeRepeating ("inst", 1f, 1f);
		g = GameObject.FindWithTag ("Player");
		Destroy (g, time);
		}
	
	void Update () {

		float x=Input.GetAxis ("Horizontal");
		transform.Translate (x*Time.deltaTime*speed,0, 0);
		Debug.Log ("You have catched" + count/2 + "balls");
		if (g.Equals (null))
		{
			CancelInvoke ();

		}
		Debug.Log ("the no of red balls are :"+ rc);
		Debug.Log ("the no of green balls are :"+ gc);
		Debug.Log ("the no of blue balls are :"+ bc);


	}
	void inst()
	{
		//if (t <= time)

			x = Random.Range (-10, 10);
			y = 0;
			z = 0;
			pos = new Vector3 (x, y, z);
		int var = Random.Range (1, 10);
		if (var < 3) {
			Instantiate (ball1, pos, transform.rotation);
			++bc;
		} else if (var == 3) {
			Instantiate (ball3, pos, transform.rotation);
			++rc;
		} else if (var == 4) {
			Instantiate (ball1, pos, transform.rotation);
			++bc;
		} else if (var == 5) {
			Instantiate (ball2, pos, transform.rotation);
			++gc;
		} else if (var >= 5 && var < 7) {
			Instantiate (ball2, pos, transform.rotation);
			++gc;
		} else {
			Instantiate (ball3, pos, transform.rotation);
			++rc;
		}
	}



	void OnCollisionEnter(Collision c)
	{
		++count;
		if (c.gameObject.tag == "Finish")
			Destroy (c.gameObject);

	}

}

