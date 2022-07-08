using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColorForward : MonoBehaviour
{
    Material initialMaterial;
    Renderer baseRenderer;
    // Start is called before the first frame update
    void Start()
    {
        // 1) je vais chercher MON renderer :
        baseRenderer = GetComponent<Renderer>();
        initialMaterial = baseRenderer.material; // on l'initie ici car on ne l'initie qu'une fois au Start()
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; // variable de sortie en C# = out <variable>
        Color color = Color.magenta; //couleur initiale du rayon
        bool colorHasChanged = false;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10)) 
            {
                // 2) je vais chercher le renderer de l'objet touché :
                Renderer otherRenderer = hit.transform.GetComponent<Renderer>(); 
                // 3) je change MON material avec le renderer de l'objet touché :
                if(otherRenderer != null)
                {
                    baseRenderer.material = otherRenderer.material; 
                    color = otherRenderer.material.color;
                    colorHasChanged = true;
                }
                
            }
        Debug.DrawRay(transform.position, transform.forward * 100, color, 1); // pour agrandir le rayon, il faut multiplier la direction par la longueur souhaitée, ici *100
        if(!colorHasChanged) //condition = "si le rayon ne touche rien"
        {
            GetComponent<Renderer>().material = initialMaterial; // on remet le material initial 

        }
    }
}
