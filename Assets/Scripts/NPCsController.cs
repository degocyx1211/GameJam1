using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCsController : MonoBehaviour, IInteractable
{

    public static NPCsController instance;
    [Header("Cuadro Dialogos Npc")]
    

    public bool happy;
    public bool angry;
    public bool talking;

    public Animator animatorNPC;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        angry = true;
        happy = false;
        animatorNPC = GetComponent<Animator>();
        talking = QuickTimeEvents.instance.talking;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        SetAnimator();

        if (talking && Input.GetKeyDown(KeyCode.Q))
        {
            talking = false;
            angry = true;
            happy = false;
            QuickTimeEvents.instance.wordCanvas.text = "";
        }
    }

    
    void SetAnimator()
    {
        animatorNPC.SetBool("happy", happy);
        animatorNPC.SetBool("angry", angry);
        animatorNPC.SetBool("talking", talking);
    }

    public void Interact()
    {

        //PlayerController.instance.charController.enabled(false);


       
        if (Input.GetKeyDown(KeyCode.F) && !talking)
        {
            
            //texto.gameObject.SetActive(false);

            QuickTimeEvents.instance.WordsToKeys();
            talking = true;
            QuickTimeEvents.instance.talking = talking;
            angry = false;
        }
    }

}
