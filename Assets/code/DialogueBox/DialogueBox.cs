using UnityEngine;

public class DialogueBox : MonoBehaviour {
    public float buttonWidthPercent = .20f;
    public float buttonHeightPercent = .05f;
    public float verticalButtonDisp = .6f;
    public float horizontalButtonDisp = .5f;
    public float lettersPerSecond = 1.5f;
    public GUISkin customSkin;

    public Camera FrontStuff;

    public string theText = "";

    private bool finished = false;
    public bool Finished { get { return finished; } }

    private float currentLetter = 0f;
    private string _sliceString;

    void OnGUI()
    {

        var buttonWidth = Screen.width * buttonWidthPercent;
        var buttonHeight = Screen.height * buttonHeightPercent;

        var buttonBorder = new Rect(Screen.width * horizontalButtonDisp - buttonWidth / 2,
            Screen.height * verticalButtonDisp + buttonHeight * 1,
            buttonWidth, buttonHeight);

        if(theText.Length > 0)
        {
            if (Mathf.FloorToInt(currentLetter) < theText.Length)
            {
                float newLetter = currentLetter + Time.deltaTime*lettersPerSecond;
                _sliceString = theText.Substring(0, Mathf.FloorToInt(newLetter));

                currentLetter = newLetter;
            }
            else
            {
                finished = true;
            }

            Debug.Log(currentLetter);
            //finished = Mathf.FloorToInt(currentLetter) >= theText.Length;
        }
        GUI.Box(buttonBorder, _sliceString, customSkin.box);

        if(FrontStuff != null)
            FrontStuff.Render();

    }

    public void LoadDialogue(string stuff)
    {
        theText = stuff;
        finished = false;
        currentLetter = 0f;
    }








}
