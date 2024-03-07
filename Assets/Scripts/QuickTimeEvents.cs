
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvents : MonoBehaviour
{

    public TextMeshPro texto;

    private int currentIndex;
    public string[] keyWords;
    public KeyCode[] CommandSucesion;
    private bool talking = false;
    void Start()
    {
        currentIndex = 0;
        texto.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && talking && Input.anyKeyDown)
        {
                PressedKeys();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Reset();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Activar el texto
            texto.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                texto.gameObject.SetActive(false);
                WordsToKeys();
                talking = true;
            }
            else
            {

            }
        }

    }
    private void Reset()
    {
        talking = false;
        currentIndex = 0;
        texto.gameObject.SetActive(false);
    }

    void PressedKeys ()
    {
        
       
        if (Input.GetKeyDown(CommandSucesion[currentIndex]))
        {
            // La tecla presionada es la correcta en la secuencia
            currentIndex ++;
          
            // Si hemos llegado al final de la secuencia, ejecutar el comando
            if (currentIndex >= CommandSucesion.Length)
            {
                ExecuteCommand();
            }
    }
        else
        {      // Si la tecla presionada no es la correcta, reiniciar la secuencia
            currentIndex = 0;
        }

      
        // Verificar si el jugador presiona la tecla correcta en la secuencia
        
       
    }
    void ExecuteCommand()
    {
        
        Debug.Log("Comando ejecutado!");
       

    }
    void WordsToKeys()
    {
        
        int indexRandom = Random.Range(0, keyWords.Length);
        string word = keyWords[indexRandom];
        word = word.ToUpper();

        CommandSucesion = new KeyCode[word.Length];
        KeyCode keyCode;
        for (int i = 0; i < word.Length; i++)
        {
            string character = word[i].ToString();
            keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), character);
            CommandSucesion[i] = keyCode;
        }

    }


  


    















}
