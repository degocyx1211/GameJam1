using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;
using TMPro;

public interface IInteractable
{
    void Interact();
}
public class Interactor : MonoBehaviour
{
   
    public float rayDistance = 1f;
    public LayerMask npcLayer;
    private RaycastHit rayo;

    public GameObject panelTextoNPC;
    public TextMeshProUGUI texto;
    


    private void Start()
    {
       
    }
    void Update()
    {
        DetectObjects ();
        
    }



    void DetectObjects()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out rayo, rayDistance, npcLayer))
        {
            if (rayo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                interactObj.Interact();
            panelTextoNPC.SetActive(true);
            rayo.collider.gameObject.transform.forward = -transform.forward;
        }
        else
        {
            panelTextoNPC.SetActive(false);
        }
    } 

     void OnDrawGizmosSelected()
     {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
     
     }



}




   
