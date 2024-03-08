using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour,IInteractable
{
    // Start is called before the first frame update

    [Header("Cuadro Dialogos Npc")]
    public TextMeshPro texto;

    private bool talking;

    void Start()
    {
        talking = QuickTimeEvents.instance.talking;
    }

    void Update()
    { 
        if (talking && Input.GetKeyDown(KeyCode.Escape)) { 
            talking = false;
        }
    }
    public void Interact()
    {
        
        //texto.gameObject.SetActive(true);
        
        if (Input.GetKeyDown(KeyCode.F) && !talking)
        {
            
            //texto.gameObject.SetActive(false);

            QuickTimeEvents.instance.WordsToKeys();
            talking = true;
            QuickTimeEvents.instance.talking = talking;
        }
    }
}