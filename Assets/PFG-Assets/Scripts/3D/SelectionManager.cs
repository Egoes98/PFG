using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Camera cam;
    GameObject interactedObj;

    void Update()
    {
        //Eliminar un objeto que probablemnet ya no este en el punto de mira
        if(interactedObj != null)
        {
            //Indicamos a el script de interaccion que no esta siendo visto el objeto
            interactedObj.GetComponent<ObjectInteraction>().isLooking(false);
            interactedObj = null;
        }

        //La variable que guarda los datos del objeto colisionado
        RaycastHit hit;
        //Lanzamos el rayo el cual sale desde el centro de la camara
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.5f))
        {
            //Comprobamos si el objeto es interactuable miarndo a su tag
            if (hit.transform.tag == "Interactable")
            {
                //Añdimos el objeto a la variable para luego poder volver a llamer al ObjectInteraction
                interactedObj = hit.transform.gameObject;
                //Avisamos de que el objeto esta siendo utilizado.
                interactedObj.GetComponent<ObjectInteraction>().isLooking(true);
            }
        }
    }
}
