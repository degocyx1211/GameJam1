using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsController : MonoBehaviour
{
    public bool happy;
    public bool angry;

    public Animator animatorNPC;

    // Start is called before the first frame update
    void Start()
    {
        angry = true;
        happy = false;
        animatorNPC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Afecta el grounded para saber cuando está en el suelo
        animatorNPC.SetBool("happy", happy);
        animatorNPC.SetBool("angry", angry);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            angry = false;
            happy = true;
        }
    }




}
