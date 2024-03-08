using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;
using TMPro;

public interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
   
    public float rayDistance = 1f;
    public LayerMask npcLayer;
    private RaycastHit rayo;

    public GameObject canvasTextNPC;
  
    public Vector3 size;
    public bool m_HitDetect;
    
       

    private void Start()
    {
        

    }
    void Update()
    {
        DetectObjects ();
        
    }



    void DetectObjects()
    {
     
        if (Physics.Raycast(transform.position, transform.forward, out rayo, rayDistance, npcLayer)&& !NPCsController.instance.happy)
        {
            Transform childTransform = rayo.collider.gameObject.transform.GetChild(7);
            canvasTextNPC = childTransform.gameObject;

            if (rayo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                
                interactObj.Interact();
            canvasTextNPC.SetActive(true);
            rayo.collider.gameObject.transform.forward = -transform.forward;
        }
        else
        {
            canvasTextNPC.SetActive(false);
        }

        
    } 

     void OnDrawGizmosSelected()
     {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
     
     }



}




   
