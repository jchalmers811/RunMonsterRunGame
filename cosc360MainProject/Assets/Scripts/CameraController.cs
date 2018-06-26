using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;

	
	private Vector3 offset;
	
	void Start () //called on first frame that the script it active (usually first frame in game).
	{
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate () //called before each frame rendered but better than Update in this case(most code in here).
	{
		if (player) {
			transform.position = player.transform.position + offset;
		}
	}
	
}
