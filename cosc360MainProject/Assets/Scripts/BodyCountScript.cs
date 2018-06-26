using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BodyCountScript : MonoBehaviour {


	public static Text bodyCountMele;
	static int bc;

	// Use this for initialization
	void Start () {
		bodyCountMele = GetComponent<Text> ();
	

		}

			public static void getBodyCount(){
				bc = EnemyController.meleBodyCount;
				//Debug.Log (bc);
				bodyCountMele.text += bc.ToString ();

			}
}

