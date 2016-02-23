using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {



	//For physics~!
	public float speed;
	private Rigidbody rb;

	public Text scoreText;
	public Text winText;
	private int score;



	//class start functionality on load
	void Start(){
		winText.text = "";
		rb = GetComponent<Rigidbody> ();
		score = 0;
		updateScore ();

	}

	void Update(){
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}

	void FixedUpdate(){
		//curious that they didnt use ENUM here, maybe for custom axis?
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//cleanup to remove in-bewtween vars
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
		
	}

	int getScore(){
		return score;
	}

	void updateScore(){
		scoreText.text = "Score: " + score.ToString();
		if (score >= 4) {
			winText.text = "You win!";
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive(false);
			score++;
			updateScore();
		}
	}

}
