using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsController : MonoBehaviour
{
    

    public bool happy;
    public bool angry;
    public bool talking;

    public Animator animatorNPC;

  
    // Start is called before the first frame update
    void Start()
    {
        angry = true;
        happy = false;
        animatorNPC = GetComponent<Animator>();
        //talking = QuickTimeEvents.instance.talking;
    }

    // Update is called once per frame
    void Update()
    {
       //SetAnimator();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && talking && Input.anyKeyDown)
        {
            QuickTimeEvents.instance.PressedKeys();
            happy = true;
            angry = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        QuickTimeEvents.instance.Reset();

    }

    void SetAnimator()
    {
        animatorNPC.SetBool("happy", happy);
        animatorNPC.SetBool("angry", angry);
        animatorNPC.SetBool("talking", talking);
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        angry = false;
    //        happy = true;
    //    }
    //}




}
