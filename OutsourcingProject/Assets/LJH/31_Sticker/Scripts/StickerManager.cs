using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StickerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> card0;
    [SerializeField] private List<GameObject> card1;
    [SerializeField] private List<GameObject> card2;
    [SerializeField] private List<GameObject> card3;
    [SerializeField] private List<GameObject> card4;
    [SerializeField] private List<GameObject> card5;
    [SerializeField] private List<GameObject> card6;
    [SerializeField] private List<GameObject> card7;
    [SerializeField] private List<GameObject> card8;
    [SerializeField] private List<GameObject> card9;

    private Dictionary<int, List<GameObject>> cardDic;

    private int currStage;
    private int numCorrectPairs = 0;
    private int numAllPairs;
    private List<int> cardIndex = new List<int>();
    private GameObject currSelectedCard = null;


    private int CurrStage { 
        get { return currStage; } 
        set { currStage = value; SetStage(currStage); } }

    // Start is called before the first frame update
    void Start()
    {
        cardDic = new Dictionary<int, List<GameObject>> { { 0, card0}, { 1, card1}, { 2, card2 }, { 3, card3},
        { 4, card4},
        { 5, card5},
        { 6, card6},
        { 7, card7},
        { 8, card8},
        { 9, card9},
        };

        SetStage(1);
    }

    private void SetStage(int stage)
    {
        ResetStage();
        switch (stage)
        {
            //Set 2 pairs of card
            case 1:
            case 2:
            case 3:
                numAllPairs = 2;
                SetCards(2);
                break;
            //Set 3 pairs of card
            case 4:
            case 5:
            case 6:
                numAllPairs = 3;
                SetCards(3);
                break;
            //Set 4 pairs of card
            case 7:
            case 8:
                numAllPairs = 4;
                SetCards(4);
                break;
            case 9:
                //Finish
                break;

        }
    }

    private void ResetStage()
    {
        foreach(KeyValuePair<int, List<GameObject>> pair in cardDic)
        {
           foreach(GameObject card in pair.Value)
            {
                card.SetActive(false);
                int n = int.Parse(card.name.Split("_")[0]);
                Button btnCard = card.GetComponent<Button>();
                btnCard.onClick.RemoveAllListeners();
                btnCard.onClick.AddListener(() => OnClickCard(n));
            }
        }
        numCorrectPairs = 0;
        cardIndex.Clear();
    }

    private void SetCards(int numOfPairs)
    {
        while (cardIndex.Count < numOfPairs)
        {
            int r = Random.Range(0, 10);
            if (cardIndex.Contains(r).Equals(false))
                cardIndex.Add(r);
        }

        foreach (int i in cardIndex)
        {
            foreach (GameObject go in cardDic[i])
            {
                go.SetActive(true);
                go.transform.localPosition = new Vector3(Random.Range(-700f, 700f), Random.Range(-400f, 400f), 0f);
                go.transform.localEulerAngles = new Vector3(0f, 0f, Random.Range(-180f, 180f));
            }
        }
    }

    private void OnClickCard(int number)
    {
        if(currSelectedCard is null)
        {
            currSelectedCard = EventSystem.current.currentSelectedGameObject;
            return;
        }
        else
        {
            if (currSelectedCard.name.Split("_")[0].Equals(number.ToString()) && currSelectedCard.name != EventSystem.current.currentSelectedGameObject.name)
            {
                Debug.Log("Correct !");
                currSelectedCard.SetActive(false);
                EventSystem.current.currentSelectedGameObject.SetActive(false);
                currSelectedCard = null;

                numCorrectPairs += 1;
                if(numCorrectPairs >= numAllPairs)
                {
                    CurrStage += 1;
                }
            }
            else
            {
                Debug.Log(currSelectedCard.name+" and "+ EventSystem.current.currentSelectedGameObject.name + " Wrong ..");
                currSelectedCard = null;
            }
        }
    }
}
