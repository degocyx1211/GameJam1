using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}
public class Interactor : MonoBehaviour
{
   
    public float rayDistance = 10f;
    public LayerMask npcLayer;
    private RaycastHit rayo;

    void Update()
    {
        DetectObjects ();
    }

    void DetectObjects()
    {
        if (Physics.Raycast(transform.position, transform.forward, out rayo, rayDistance, npcLayer))
            if (rayo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                interactObj.Interact();
            
  
      
    } 

     void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
     
    }



}




   
