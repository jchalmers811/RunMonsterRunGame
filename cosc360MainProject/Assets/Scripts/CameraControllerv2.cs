using UnityEngine;
using System.Collections;

public class CameraControllerv2 : MonoBehaviour {

	public GameObject player;

	public float zoomSpeed = 20f;

	private Vector3 offset;

	void Start () //called on first frame that the script it active (usually first frame in game).
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () //called before each frame rendered but better than Update in this case(most code in here).
	{
		transform.position = player.transform.position + offset;

		float scroll = Input.GetAxis ("Mouse ScrollWheel");

		print (scroll);

		if (scroll != 0.0f) {
			Camera.main.orthographicSize += scroll*zoomSpeed;
		}
	}

}
