using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimationTransitions : MonoBehaviour {
    private Animator anim;

    // Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}

    // Update is called once per frame
	void Update ()
	{
	    if (Input.GetMouseButton(0))
	    {
	        if (!(anim.GetCurrentAnimatorStateInfo(1).IsName("UI_Chatter1") || anim.GetCurrentAnimatorStateInfo(1).IsName("UI_Chatter2")))
	        {
	            anim.SetTrigger("chatter1");
	        }
	        else
	        {
	            anim.SetTrigger("chatterContinue");
	        }
	    }
	}
}
