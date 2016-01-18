using UnityEngine;


public class BaseUnitAI : MonoBehaviour {


    private bool selected = false;
    private bool onTheMove = false;
    public float speed = 1.0f;
    public float stopDist = .1f;
    Vector3 targetLocation;

    private CharacterController controller;
    
	// Use this for initialization
	void Start () {
        controller = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(onTheMove)
        {
            //rotate
            var newRotation = Vector3.RotateTowards(controller.transform.forward, targetLocation, Mathf.PI, Mathf.PI);
            //this.transform.LookAt(targetLocation, Vector3.up);
            controller.transform.LookAt(targetLocation, Vector3.up);

            //move
            var step = speed * Time.deltaTime;
            var floatingDirection = (targetLocation - controller.transform.position).normalized * step;
            var finalDirection = new Vector3(floatingDirection.x, -3, floatingDirection.z);
            controller.Move(finalDirection);


            //Don't get too close
            if(Vector3.Distance(this.transform.position, targetLocation) <= stopDist)
            {
                onTheMove = false;
            }
        }
        else
        {
            //idle here
        }
	}

    public void WasSelected()
    {
        selected = true;
    }

    public void WasDeSelected()
    {
        selected = false;
    }

    public void RecieveOrderTo(Vector3 location)
    {
        if (selected)
        {
            targetLocation = new Vector3(location.x, controller.transform.position.y, location.z);
            onTheMove = true;
        }
    }

}
