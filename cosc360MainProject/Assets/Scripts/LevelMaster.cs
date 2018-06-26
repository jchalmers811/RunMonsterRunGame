using UnityEngine;
using System.Collections;


public class LevelMaster : MonoBehaviour {

	public int barLengthMultiplier = 2;

	private int emptyBarLength = 100;
	private int healthBarLength;
	private int stamBarLength;
	
	// Use this for initialization
	void Start () {
		emptyBarLength = emptyBarLength * barLengthMultiplier;

	}
	
	/*   I have no attached the HUD to the game over canvas - this will now check to make sure the players health
	 * is above 0, if so it will display the HUD for the player, if not it is not loaded which allows the game over
	 * pop up to run smoothly. eg without the HUD displayed over top. 
	 * */
	void OnGUI() {
		if (PlayerHealth.health > 0 && TileLoaderv5.GameWon == false) { 
			// Show player score in white on the top left of the screen
			GUI.color = Color.white;   
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.fontStyle = FontStyle.Bold;
			GUI.Label (new Rect (Screen.width - 150, 20, 300, 100), "Score: " + GameMaster.playerScore);

			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.fontStyle = FontStyle.Bold;
			GUI.Label (new Rect (Screen.width - 150,50,300, 100), "Time: " + (int) Time.timeSinceLevelLoad);

		

			stamBarLength = (int) PlayerStamina.curStamina * barLengthMultiplier;
			// Show the player lives in red on the top right of the screen
		


			GUI.BeginGroup (new Rect (20, 50, emptyBarLength, 20)); 
			GUIDrawRect(new Rect (0,0, emptyBarLength, 20), Color.black);
				// draw the filled-in part:
			GUI.BeginGroup (new Rect (0, 0, stamBarLength, 20));
			GUIDrawRect(new Rect (0,0, stamBarLength, 20), Color.green);
			GUI.EndGroup ();

			GUI.EndGroup ();


			healthBarLength = (int) PlayerHealth.health * barLengthMultiplier; 
			GUI.color = Color.white;
			GUI.BeginGroup (new Rect (20, 20, emptyBarLength, 20)); 
			GUIDrawRect(new Rect (0,0, emptyBarLength, 20), Color.black);

				// draw the filled-in part:
			GUI.BeginGroup (new Rect (0, 0, healthBarLength, 20));
			GUIDrawRect(new Rect (0,0, healthBarLength, 20), Color.red);
			GUI.EndGroup ();

			GUI.EndGroup ();




		}
	}
		

	// Note that this function is only meant to be called from OnGUI() functions.
	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;

	// Note that this function is only meant to be called from OnGUI() functions.
	public static void GUIDrawRect( Rect position, Color color )
	{
		if( _staticRectTexture == null )
		{
			_staticRectTexture = new Texture2D( 1, 1 );
		}

		if( _staticRectStyle == null )
		{
			_staticRectStyle = new GUIStyle();
		}

		_staticRectTexture.SetPixel( 0, 0, color );
		_staticRectTexture.Apply();

		_staticRectStyle.normal.background = _staticRectTexture;

		GUI.Box( position, GUIContent.none, _staticRectStyle );


	}
}