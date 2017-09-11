using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour {

    public float alpha;
    public bool isHidden;

	// Use this for initialization
	void Start () {
		
	}

    public void Hide()
    {
        isHidden = true;
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        Color tmp = sr.color;
        tmp.a = alpha;
        sr.color = tmp;
    }

    public void Appear()
    {
        isHidden = false;
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        Color tmp = sr.color;
        tmp.a = 1.0f;
        sr.color = tmp;
    }
}
