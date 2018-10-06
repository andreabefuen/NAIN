﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNodo : MonoBehaviour {

    public GameObject nodo;
    public GameObject nodoInicial;
    public GameObject[,] matrixNodo;
    public int rows;
    public int columns;


    public int distanciaEntreNodos;

    private Vector3 realPosition;
    private GameObject aux;


	// Use this for initialization
	void Start () {

        realPosition = nodoInicial.transform.position;
        matrixNodo = new GameObject[rows,columns];

        for (int f = 0; f< rows; f++)
        {
            for(int c =0; c< columns; c++)
            {
                
                aux = Instantiate(nodo, new Vector3(realPosition.x + distanciaEntreNodos * f, realPosition.y, realPosition.z + distanciaEntreNodos * c), Quaternion.identity);
               /* if( Physics.OverlapSphere(aux.transform.position, 1, LayerMask.NameToLayer("wall")).Length > 0)
                {
                    Debug.Log("si");
                    Destroy(aux);
                }*/
                
            }
          

        }



	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
