using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWithRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; // variable de sortie en C# = out <variable>
        
        Color color = Color.red; //couleur initiale du rayon
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10)) 
            {
                Debug.Log($"{hit.transform.name} touché !"); //renvoie le nom de l'objet que l'on a touché > on peut lui faire subir des choses
                hit.transform.position += transform.forward * Time.deltaTime * 3f; // l'objet va avancer de 3 par seconde dans la direction où il a été touché
                color = Color.green; // le rayon devient vert quand il touche un objet
            }
        Debug.DrawRay(transform.position, transform.forward * 10, color, 3); // pour agrandir le rayon, il faut multiplier la direction par la longueur souhaitée, ici *100

    }

}


/*

PRINCIPE DE RAYCASTING : on va caster un rayon à partir d'une position, qui ira tout droit(forward/axe z) et nous renvoit si elle a touché qqch ou pas >>> pratique pour fa/ZONE d'OMBRE  
Debug.DrawRay(<position du rayon>, <direction du rayon>, <couleur du rayon>, <durée d'affichage du rayon>)

NORMALISATION D'UN VECTEUR : traduction d'un vecteur pour n'en garder que l'unité = on retire sa longueur pour ne garder que sa direction.
> <point d'arrivée> - <point de départ> = un vecteur qu'on va normaliser

*/