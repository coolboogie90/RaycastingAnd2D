using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfTargetisVisible : MonoBehaviour
{
    public Transform target; //NE PAS OUBLIER DE SPECIFIER LA TARGET DANS LE COMPONENT UNITY
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        //Debug.DrawRay(transform.position, transform.forward, Color.magenta);
        RaycastHit hit;

        Color color = Color.red;

        if(Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.transform == target)
            {
                color = Color.green;
            }
        }

        Debug.DrawLine(transform.position, target.position, color, 3);

    }
}

/* 
NORMALISATION D'UN VECTEUR : traduction d'un vecteur pour n'en garder que l'unité = on retire sa longueur pour ne garder que sa direction.
> <point d'arrivée> - <point de départ> = un vecteur 
Puis on va normaliser le vecteur obtenu par la soustraction

Avec ce script, on utilise le Raycasting quand on connait la direction de la cible et on vérifie si on la touche bien ou pas, s'il y a un obstacle entre le rayon et la cible

*/