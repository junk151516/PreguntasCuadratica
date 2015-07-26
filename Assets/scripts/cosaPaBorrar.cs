using UnityEngine;
using System.Collections;

public class cosaPaBorrar : MonoBehaviour {
	float deltaCosa = 0.5f;
	float tiempoDeCosa;
	float corrector = -0.01f;
	public GameObject cosaParaSaber;

	public Canvas elcanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > tiempoDeCosa && cosaParaSaber.activeSelf)
		{
			tiempoDeCosa = Time.time+deltaCosa;
			corrector = corrector * (-1);
			elcanvas.planeDistance +=corrector;
			//Debug.Log ("dd");
		}
	}
}
