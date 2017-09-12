using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour {

    private List<Collider2D> colliderlist;

	// Use this for initialization
	void Start () {
        Collider2D collider = this.GetComponent<CircleCollider2D>();
        //collider.OverlapCollider(collider.)
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Hideable>().Hide();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Hideable>().Appear();
        }
    }
}
