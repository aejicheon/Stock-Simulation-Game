using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI; // Selector 스크립트에 접근하기 위한 네임스페이스

public class MovePriceMy : MonoBehaviour
{
    public Button yourButton;
    private GameObject gameManager;
    public Selector selector; // Selector 스크립트에 접근하기 위한 변수

    void Start()
    {
        yourButton = GameObject.Find("ButtonMesu").GetComponent<Button>();
        yourButton.onClick.AddListener(() =>
        {
            // ButtonMesu가 클릭되었을 때 실행할 코드
            TaskOnClickPriceMove();
            InvokeRepeating("UpdateSamsungPNL", 0, 5);
        });
        gameManager = GameObject.Find("GameManager");
    }
    void UpdateSamsungPNL()
    {
        if (selector != null && gameManager != null)
        {
            string indicatorText = selector.GetIndicator2Text();
            string indicator1Text = selector.GetIndicator1Text();

            GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
            if (gameManagerScript != null)
            {
                gameManagerScript.SamPNL(indicatorText);
                gameManagerScript.MedoMaEip(indicatorText);
            }
            else
            {
                Debug.LogError("GameManager 스크립트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Selector 스크립트 또는 GameManager를 찾을 수 없습니다.");
        }
    }
    void TaskOnClickPriceMove()
    {
        //Debug.Log("버튼이 클릭되었습니다.");
        if (selector != null)
        {
            string indicatorText = selector.GetIndicator2Text();
            string indicator1Text = selector.GetIndicator1Text();

            // GameManager 스크립트에 접근하여 indicatorText 값을 TotalMoney Text UI 요소에 할당
            if (gameManager != null)
            {
                GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
                if (gameManagerScript != null)
                {
                    gameManagerScript.PNL(indicator1Text, indicatorText);
}
                else
                {
                    Debug.LogError("GameManager 스크립트를 찾을 수 없습니다.");
                }
            }
        }
        else
        {
            Debug.LogError("Selector 스크립트를 찾을 수 없습니다.");
        }
    }
}