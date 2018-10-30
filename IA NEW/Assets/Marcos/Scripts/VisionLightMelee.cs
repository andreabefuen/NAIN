using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionLightMelee : MonoBehaviour {

	public float range=300f;
	private Light thisLight;
	private Color lightColor= new Color(0f,250f,0f,180f);
	private Vector3 rotationLight;
	private float lightAngle;
	private EnemyScriptMarcos shootThis;
	// Use this for initialization
	void Start () {
		//thisLight = GetComponent<Light> ();
		thisLight=this.GetComponentInChildren<Light>();
		/*lightAngle = Mathf.Acos (1 / (Mathf.Sqrt (range * range + 1)));
		rotationLight = new Vector3 (lightAngle,0f,0f);
		transform.Rotate (rotationLight); */
		shootThis = this.GetComponent<EnemyScriptMarcos> ();
		range = shootThis.VisionRangeGet();
		//Debug.Log (range);
		thisLight.range = range;

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (shootThis.GetRealDist ());
		if (shootThis.GetPursuit ()) {
			lightColor = new Color (250f, 0f, 0f, 180f);
		} else if (shootThis.GetRealDist () < (range * 2f)) {
			
			//Debug.Log (range);
			lightColor = new Color (250f, 250f, 0f, 180f);
		} else {
			lightColor= new Color(0f,250f,0f,180f);
		}
		thisLight.color = lightColor;

		
	}
}
