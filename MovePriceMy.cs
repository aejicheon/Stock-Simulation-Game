using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI; // Selector ��ũ��Ʈ�� �����ϱ� ���� ���ӽ����̽�

public class MovePriceMy : MonoBehaviour
{
    public Button yourButton;
    private GameObject gameManager;
    public Selector selector; // Selector ��ũ��Ʈ�� �����ϱ� ���� ����

    void Start()
    {
        yourButton = GameObject.Find("ButtonMesu").GetComponent<Button>();
        yourButton.onClick.AddListener(() =>
        {
            // ButtonMesu�� Ŭ���Ǿ��� �� ������ �ڵ�
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
        //Debug.Log("��ư�� Ŭ���Ǿ����ϴ�.");
        if (selector != null)
        {
            string indicatorText = selector.GetIndicator2Text();
            string indicator1Text = selector.GetIndicator1Text();

            // GameManager ��ũ��Ʈ�� �����Ͽ� indicatorText ���� TotalMoney Text UI ��ҿ� �Ҵ�
            if (gameManager != null)
            {
                GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
                if (gameManagerScript != null)
                {
                    gameManagerScript.PNL(indicator1Text, indicatorText);
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