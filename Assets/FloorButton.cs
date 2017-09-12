using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour {

    public GameObject door;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("BUTTON!");
        door.SetActive(false);
        door.active = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        door.SetActive(true);
        door.active = true;
    }
}
