using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private float movehorizontal;
	private float movevertical;
	private int count;
	public Text countText;
	public Text wintext;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		wintext.text = "";
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}


	void FixedUpdate()
	{

		//movehorizontal = Input.GetAxis ("Horizontal");
		//movevertical = Input.GetAxis ("Vertical");
		movehorizontal = Input.acceleration.x;
		movevertical = Input.acceleration.y;

		Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}

	}



	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if(count >=23){wintext.text = "You Win";
			SceneManager.LoadScene ("rab_scene");}
	}

}
