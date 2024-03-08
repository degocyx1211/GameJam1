using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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
    
    void Update()
    {
        DetectObjects();
    }
    void DetectObjects()
    {
     
        if (Physics.Raycast(transform.position, transform.forward, out rayo, rayDistance, npcLayer))
        {
            Transform childTransform = rayo.collider.gameObject.transform.GetChild(7);
            canvasTextNPC = childTransform.gameObject;
            if(!rayo.collider.gameObject.GetComponent<NPCsController>().happy)
            {
                canvasTextNPC.SetActive(true);
                if (rayo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && Input.GetKeyDown(KeyCode.F))
                {
                    QuickTimeEvents.instance.npcController = rayo.collider.gameObject.GetComponent<NPCsController>();
                    interactObj.Interact();
                }
                rayo.collider.gameObject.transform.forward = -transform.forward;
            }         
        }
        else
        {
            if (canvasTextNPC && canvasTextNPC.activeSelf)
            {
                canvasTextNPC.SetActive(false);
            }
            canvasTextNPC = null;
        }      
    } 

     void OnDrawGizmosSelected()
     {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
     
     }



}




   
