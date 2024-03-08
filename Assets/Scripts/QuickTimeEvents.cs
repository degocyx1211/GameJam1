
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvents : MonoBehaviour
{

    public static QuickTimeEvents instance;

    [Header("Words System")]
    private int currentIndex;
    public string[] keyWords;
    public KeyCode[] CommandSucesion;

    public TextMeshProUGUI wordCanvas;

    private int npcCount;
    public int excuteCount = 0;
    public bool talking = false;
    public NPCsController npcController;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //actualNpc = SpawnManager.instance.NPCCount;
        currentIndex = 0;
        wordCanvas = GameObject.Find("CanvasWords").GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (talking && Input.anyKeyDown)
        {
            PressedKeys();
        } 
    }
 
    public void Reset()
    {
        talking = false;
        currentIndex = 0;

        //texto.gameObject.SetActive(false);
    }

    public void PressedKeys()
    {
        if(currentIndex < CommandSucesion.Length)
        {
            if (Input.GetKeyDown(CommandSucesion[currentIndex]))
            {
                Colorize();
                Debug.Log(CommandSucesion[currentIndex]);
                // La tecla presionada es la correcta en la secuencia
                currentIndex++;

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
        }

    }
    void ExecuteCommand()
    {
        Debug.Log("Comando ejecutado!");
        talking = false;
        wordCanvas.text = "";
        npcController.happy = true;
        excuteCount++;
        if(excuteCount == SpawnManager.instance.NPCCount)
        {
            StartCoroutine(SpawnNPC());
        }
        currentIndex = 0;
        if(excuteCount == 3)
        {

        }

    }

    IEnumerator SpawnNPC()
    {
        yield return new WaitForSeconds(6);
        npcController.DestroyNpc();
        yield return new WaitForEndOfFrame();
    }

    void Colorize() {
        string[] listString = new string[CommandSucesion.Length];
        string letterKeyCode;
        if (currentIndex == 0)
        {
            letterKeyCode = CommandSucesion[0].ToString();
            listString[0] = "<color=yellow>" + letterKeyCode + "</color>";
            for (int i = currentIndex + 1; i < CommandSucesion.Length; i++)
            {
                letterKeyCode = CommandSucesion[i].ToString();
                listString[i] = letterKeyCode;
            }
        }
        else {         
            for (int i = 0; i <= currentIndex; i++)
            {
                letterKeyCode = CommandSucesion[i].ToString();
                listString[i] = "<color=yellow>" + letterKeyCode + "</color>";
            }         
            for (int i = currentIndex + 1 ; i < CommandSucesion.Length; i++)
            {
                letterKeyCode = CommandSucesion[i].ToString();
                listString[i] = letterKeyCode;
            }
        }
        wordCanvas.text = string.Join("", listString);
    }

    public void WordsToKeys()
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
        wordCanvas.text = word;
    }
}
