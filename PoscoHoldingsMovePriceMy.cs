using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI; // Selector ��ũ��Ʈ�� �����ϱ� ���� ���ӽ����̽�

public class PoscoHoldingsMovePriceMy : MonoBehaviour
{
    public Button yourButton;
    private GameObject gameManager;

    public Selector selector; // Selector ��ũ��Ʈ�� �����ϱ� ���� ����
    void Start()
    {
        yourButton = GameObject.Find("ButtonMesu").GetComponent<Button>();
        yourButton.onClick.AddListener(() =>
        {
            // yourButton�� Ŭ���Ǿ��� �� ������ �ڵ�
            TaskOnClickPriceMove();
            InvokeRepeating("UpdatePoscoHoldingsPNL", 0, 5);
        });
        gameManager = GameObject.Find("GameManager");
    }
    void UpdatePoscoHoldingsPNL()
    {
        if (selector != null && gameManager != null)
        {
            string indicatorText = selector.GetIndicator2Text();

            GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
            if (gameManagerScript != null)
            {
                gameManagerScript.PoscHoldPNL(indicatorText); //****
                gameManagerScript.MedoMaEip(indicatorText);
            }
            else
            {
                Debug.LogError("GameManager ��ũ��Ʈ�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("Selector ��ũ��Ʈ �Ǵ� GameManager�� ã�� �� �����ϴ�.");
        }
    }
    void TaskOnClickPriceMove()
    {
        if (selector != null)
        {
            string indicatorText = selector.GetIndicator2Text();
            string indicator1Text = selector.GetIndicator1Text();
            Debug.Log("indicator2.text: " + indicatorText); //��
            Debug.Log("indicator1.text: " + indicator1Text); //��

            if (gameManager != null)
            {
                GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
                if (gameManagerScript != null)
                {
                    gameManagerScript.PoscHPNL(indicator1Text, indicatorText);//****
                }
                else
                {
                    Debug.LogError("GameManager ��ũ��Ʈ�� ã�� �� �����ϴ�.");
                }
            }
        }
        else
        {
            Debug.LogError("Selector ��ũ��Ʈ�� ã�� �� �����ϴ�.");
        }
    }
}