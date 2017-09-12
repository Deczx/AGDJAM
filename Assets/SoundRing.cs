using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRing : MonoBehaviour {

    public Color ringColor;
    [Range(0.0f, 0.5f)]
    public float thickness;
    [Range(0.0f, 0.5f)]
    public float maxRadius;
    [Range(0.01f, 4.0f)]
    public float antiAlias;
    public float lifeSpan;



    private Material renderMaterial;
    private float expandRate;
    private float currentRadius;
    private CircleCollider2D circleCollider;

	// Use this for initialization
	void Start () {
        circleCollider = this.GetComponent<CircleCollider2D>();
        renderMaterial = this.GetComponent<MeshRenderer>().material;
        renderMaterial.SetColor("_Color", Color.red);
        renderMaterial.SetFloat("_Thickness", thickness);
        renderMaterial.SetFloat("_Dropoff", antiAlias);
        renderMaterial.EnableKeyword("_ALPHABLEND_ON");
        renderMaterial.EnableKeyword("_NORMALMAP");
        renderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        circleCollider.radius = 0.1f;
        currentRadius = 0.1f;
        expandRate = maxRadius / lifeSpan;
        renderMaterial.SetFloat("_Radius", currentRadius);
        circleCollider.radius = currentRadius;
    }
	
	// Update is called once per frame
	void Update () {
        
        currentRadius += expandRate * Time.deltaTime;
        renderMaterial.SetFloat("_Radius", currentRadius);
        circleCollider.radius = currentRadius;


        if (currentRadius > maxRadius)
        {
            Destroy(this.gameObject);
        }

    }
}
