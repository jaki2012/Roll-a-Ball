using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed ;
	public GUIText countText;   //update when hit a PickUp 
	public GUIText winText;
	public GUIText timeText; 
	public AudioSource scoring;
	private int count;

	void Start(){
		count = 0;
		setCountText();
		winText.text = "";
		timeText.text = "Time: ";
	}

	void Update(){
		timeText.text = "Time: " + Time.time.ToString ("F1");
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
	
		if(other.gameObject.tag == "PickUp"){
			other.gameObject.SetActive(false);
			scoring.Play();
			count = count + 1;
			setCountText();
		}
	}

	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if(count >= 12){
			winText.text = "You Win!";
		}
	}
}