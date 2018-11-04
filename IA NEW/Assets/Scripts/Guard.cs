using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
	//Andrea
    public bool gizmosActivate;
    public Transform pathHolder;

    public float speed = 5;
    public float waitTime = 0.3f;

	//Marcos
	private EnemyScriptMarcos detectThis;


    private void Start()
    {
		//Marcos
		detectThis = this.GetComponent<EnemyScriptMarcos> ();

		//Andrea
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));

    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
		//bool activado=true;
        while (true)
        {
			//if(activado){
				//If escrito por Marcos y else lo que habia originalmente de Andrea en el bucle
				if (detectThis.GetPursuit ()) {
					yield return null;
				}
				else{
		            transform.LookAt(targetWaypoint);
		            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
		            if (transform.position == targetWaypoint)
		            {
		                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length; //Para reiniciar el contador de waypoints
		                targetWaypoint = waypoints[targetWaypointIndex];
		                targetWaypoint = waypoints[targetWaypointIndex];
		                yield return new WaitForSeconds(waitTime);
		            }
		            yield return null;
				}
			/*}
			yield return null;*/
        }
    }

    private void OnDrawGizmos()
    {
        if (gizmosActivate)
        {
            Vector3 startPosition = pathHolder.GetChild(0).position;
            Vector3 previousPosition = startPosition;
            foreach (Transform waypoint in pathHolder)
            {
                Gizmos.DrawSphere(waypoint.position, 3f);
                Gizmos.DrawLine(previousPosition, waypoint.position);
                previousPosition = waypoint.position;
            }
            Gizmos.DrawLine(previousPosition, startPosition);
        }

    }
}
