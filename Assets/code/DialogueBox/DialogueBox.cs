using UnityEngine;

public class DialogueBox : MonoBehaviour {
    public float buttonWidthPercent = .20f;
    public float buttonHeightPercent = .05f;
    public float verticalButtonDisp = .6f;
    public float horizontalButtonDisp = .5f;


	public Texture2D background;
	public GUISkin guiSkin;

	private int originalFontSize = 32;
	private float nativeResY = 530.0f;

    void OnGUI()
    {
		GUI.skin = guiSkin;
		GUIStyle backgroundStyle = new GUIStyle();
		backgroundStyle.normal.background = background;
		GUI.Label(new Rect(0,0,Screen.width, Screen.height), "", backgroundStyle);
		GUIStyle menuButton = new GUIStyle(guiSkin.button);
		menuButton.fontSize = (int) (originalFontSize * (Screen.height/nativeResY));


        float buttonWidth = Screen.width * buttonWidthPercent;
        float buttonHeight = Screen.height * buttonHeightPercent;

        var buttonBorder = new Rect(Screen.width * horizontalButtonDisp - buttonWidth / 2,
            Screen.height * verticalButtonDisp + buttonHeight * 1,
            buttonWidth, buttonHeight);
        
        GUI.Box(buttonBorder, "SomeText I guess");


        
    }






}
