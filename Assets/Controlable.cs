using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlable : MonoBehaviour {

    public enum PlayerIndex
    {
        Player1, Player2 
    }

    public PlayerIndex playerIndex;
    public float movementSpeed;
    public float sprintSpeed;
    public int sprintButton;
    public GameObject ringPrefab;
    public float ringFrequency;

    private float speed;
    private int playerNumber;
    private float timer;
    private bool firstRingHasSpawned;

	// Use this for initialization
	void Start () {
        firstRingHasSpawned = false;
        switch (playerIndex) {
            case PlayerIndex.Player1:
                playerNumber = 1;
                break;
            case PlayerIndex.Player2:
                playerNumber = 2;
                break;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("P" + playerNumber + "_Axis_" + sprintButton) !=0)
        {
            timer += Time.deltaTime;
            if (!firstRingHasSpawned)
            {
                timer = ringFrequency + 1;
            }
            if (timer > ringFrequency)
            {
                firstRingHasSpawned = true;
                GameObject obj = Instantiate(ringPrefab);
                obj.transform.position = this.transform.position;
                timer = 0.0f;
            }
            speed = sprintSpeed;
        } else
        {
            firstRingHasSpawned = false;
            timer = 0;
            speed = movementSpeed;
        }
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = speed * GetMovementAxis() * Time.deltaTime;
	}

    private Vector3 GetMovementAxis()
    {
        float axis_Horizontal = Input.GetAxis("P" + playerNumber + "_Axis_1");
        float axis_Vertical = Input.GetAxis("P" + playerNumber + "_Axis_2");
        Vector3 axisDir = new Vector3(axis_Horizontal, axis_Vertical, 0);
        return axisDir;
    }

    //public Vector3 GetRotationAxis()
    //{
    //    float axis_Horizontal = Input.GetAxis("P" + playerNumber + "_Axis_4");
    //    float axis_Vertical = Input.GetAxis("P" + playerNumber + "_Axis_5");
    //    Vector3 axisDir = new Vector3(axis_Horizontal, 0, axis_Vertical);
    //    return axisDir;
    //}
}
