using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector2 speed;
    public bool avoidCliff = false;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().flipX = speed.x < 0;
        
        if (avoidCliff)
        {
            /*On détermine l'endroit où on va tirer notre rayon */
            Vector3 origin = transform.position; //je récup la position d'origine de mon ennemi = centre de l'image
            BoxCollider2D collider = GetComponent<BoxCollider2D>(); //je vais chercher son collider
            origin.y -= collider.size.y / 2;

            if (speed.x > 0)
            {
                origin.x += collider.size.x / 2; //si ma vitesse est positive, je rajoute en x pour avoir le côté droit de mon collider
            }
            else
            {
                origin.x -= collider.size.x / 2; //si ma vitesse est négative, je rajoute en x pour avoir le côté gauche de mon collider
            }

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.2f);

            Color color = Color.green;

            if (hit.collider == null)
            {
                speed.x *= -1; //si je trouve un collider, j'inverse ma position en x
            }
            else
            {
                color = Color.red;
            }

            Debug.DrawRay(origin, Vector2.down, color);
            // https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html
        }
        transform.position += (Vector3)speed * Time.deltaTime;
        //casting d'un vecteur 2 en vecteur 3 car on a toujours un vecteur3 avec un transform
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy")) //"on va comparer le tag du composant transform au moment de la collision (qui est aussi un composant)
        {
            speed.x *= -1; //inversion de la vitesse en x pour changer la direction des ennemis quand ils entre en collision entre eux
        }
        else if (collision.transform.CompareTag("Player"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.Normalize();

            collision.rigidbody.AddForce(direction * 1000); // le personnage va rebondir au contact des ennemis
            print("test");
        }
    }
}
