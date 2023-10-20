using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour
{

    public List<Dialogue> dialogueList;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    public GameObject optionsZone;
    public GameObject buttonPrefab;
    public Dialogue currentDialogue;

    public void Awake()
    {
        dialogueList = new List<Dialogue>();

        Dialogue dialogue1 = new Dialogue("Despiertas en tu habitacion dentro de la casa donde vives solo");
        dialogueList.Add(dialogue1);
    
        Dialogue dialogue2 = new Dialogue("Es de noche y revisas tu celular para ver que hora es");
        dialogue1.SetNextDialogue(dialogue2);
        dialogueList.Add(dialogue2);

        Dialogue dialogue3 = new Dialogue("Son las 11:45 pm, te levantas y sales a la cocina por agua");
        dialogue2.SetNextDialogue(dialogue3);
        dialogueList.Add(dialogue3);

        Dialogue dialogue4 = new Dialogue("Estando en la cocina, escuchas que alguien toca tu puerta");
        dialogue3.SetNextDialogue(dialogue4);
        dialogueList.Add(dialogue4);

        Dialogue dialogue5 = new Dialogue("Vas a revisar, no ves nada, te das la vuelta y miras que atras tuyo tienes a un asaltante que va hacia ti para desmayarte a golpes");
        dialogue4.SetNextDialogue(dialogue5);
        dialogueList.Add(dialogue5);

        DialogueWithOptions dialogueWithOptions1 = new DialogueWithOptions("Esta a un rango medio de ti");
        dialogue5.SetNextDialogue(dialogueWithOptions1);
        dialogueList.Add(dialogueWithOptions1);


        Dialogue dialogue6 = new Dialogue("Te impacta, pero como tienes mas fuerza que el lo noqueas");
        dialogueList.Add(dialogue6);

        Dialogue dialogue7 = new Dialogue("No soportas el golpe y te quedas sin aire (pierdes vida)");
        dialogueList.Add(dialogue7);

        Dialogue dialogue8 = new Dialogue("Lo logras esquivar y se queda vendido y lo noqueas");
        dialogueList.Add(dialogue8);

        Dialogue dialogue9 = new Dialogue("No lo logras esquivar y te golpea (pierdes vida)");
        dialogueList.Add(dialogue9);

        DialogueOption option;

        option = new DialogueStrengthOption(10, 2, "Esperas el impacto para devolverle el golpe");
        dialogueWithOptions1.AddOption(option);
        option.SetCallback(
            () => { dialogueWithOptions1.SetNextDialogue(dialogue6); OnNextClick(); },
            () => { dialogueWithOptions1.SetNextDialogue(dialogue7); OnNextClick(); });

        option = new DialogueStrengthOption(20, 4, "Lo esquivas");
        dialogueWithOptions1.AddOption(option);
        option.SetCallback(
            () => { dialogueWithOptions1.SetNextDialogue(dialogue8); OnNextClick(); },
            () => { dialogueWithOptions1.SetNextDialogue(dialogue9); OnNextClick(); });

        

        Dialogue dialogue10 = new Dialogue("No hay mas ruido por la noche");

        dialogue7.SetNextDialogue(dialogue10);
        dialogue9.SetNextDialogue(dialogue10);

        Dialogue dialogue11 = new Dialogue("LLamas a la policia y se lo llevan");

        dialogue6.SetNextDialogue(dialogue11);;

        Dialogue dialogue12 = new Dialogue("Lo encierras de nuevo en el sotano donde escapo");

        dialogue8.SetNextDialogue(dialogue12);

        currentDialogue = dialogueList[0];
        dialogueText.text = currentDialogue.Text;
        nextButton.onClick.AddListener(OnNextClick);
    }


    public void OnNextClick()
    {

        currentDialogue = currentDialogue.NextDialogue;

        dialogueText.text = currentDialogue.Text;
        if (currentDialogue is DialogueWithOptions)
        {
            foreach(DialogueOption option in ((DialogueWithOptions)currentDialogue).OptionList)
            {
                GameObject button= Instantiate(buttonPrefab);
                button.transform.SetParent(optionsZone.transform);
                button.GetComponentInChildren<TextMeshProUGUI>().text = option.Text;
                button.GetComponent<Button>().onClick.AddListener(()=>
                {
                    option.PickOption();
                    foreach(Transform child in optionsZone.transform)
                    {
                        Destroy(child.gameObject);
                    }
                }
                );
            }
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
        }

        
    }

}
