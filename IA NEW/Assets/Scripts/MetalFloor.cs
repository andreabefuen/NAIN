using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalFloor : MonoBehaviour
{
	public float SoundRange;

	private GameObject[] enemiesMelee;
	private GameObject[] enemiesShoot;
	private bool sound, inTrigger;
	private float distanceEM;
	private ShootEnemy shootThis;
	private EnemyScriptMarcos hitThis;

    // Start is called before the first frame update
    void Start()
    {
		enemiesMelee = GameObject.FindGameObjectsWithTag("EnemyMelee");
		enemiesShoot = GameObject.FindGameObjectsWithTag("EnemyShoot");
		sound = false;
		inTrigger = false;
        
    }

    // Update is called once per frame
    void Update()
    {
		if(sound){
			Melee(true);
			Range(true);
		}
		else{
			
			if(inTrigger){
				Debug.Log("Estoy en el else");
				Melee(false);
				Range(false);
				inTrigger=false;
			}
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			sound = true;
			inTrigger=true;
		}
	}

	private void OnTriggerExit(){
		sound = false;
	}

	private void Melee(bool pursuit){
		foreach(GameObject enemy in enemiesMelee){
			distanceEM = Mathf.Abs (Vector3.Distance (this.transform.position, enemy.transform.position));
			if(distanceEM < SoundRange){
				hitThis = enemy.GetComponent<EnemyScriptMarcos> ();
				Debug.Log("Esta a rango: "+ enemy.name);
				hitThis.SetPursuit(pursuit, this.transform);
			}
		}
	}

	private void Range(bool pursuit){
		foreach(GameObject enemy in enemiesShoot){
			distanceEM = Mathf.Abs (Vector3.Distance (this.transform.position, enemy.transform.position));
			if(distanceEM < SoundRange){
				shootThis = enemy.GetComponent<ShootEnemy> ();
				Debug.Log("Esta a rango: "+ enemy.name);
				shootThis.SetPursuit(pursuit, this.transform);
			}
		}
	}


}
