using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI; // Selector ��ũ��Ʈ�� �����ϱ� ���� ���ӽ����̽�

public class MedoPoscoFuture : MonoBehaviour
{
    private Button yourButton;
    private GameObject gameManager;
    public Selector selector; // Selector ��ũ��Ʈ�� �����ϱ� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        // ��ư�� �ڵ�� ã���ϴ�. ��ư�� �̸��� "YourButton"�� ���
        yourButton = GameObject.Find("ButtonMedo").GetComponent<Button>();

        // ��ư�� Ŭ�� �̺�Ʈ �����ʸ� �߰��մϴ�.
        yourButton.onClick.AddListener(TaskOnClick);

        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        //Debug.Log("��ư�� Ŭ���Ǿ����ϴ�.");
        if (selector != null)
        {
            string indicatorText = selector.GetIndicator2Text(); //��
            string indicator1Text = selector.GetIndicator1Text(); //��

            // GameManager ��ũ��Ʈ�� �����Ͽ� indicatorText ���� TotalMoney Text UI ��ҿ� �Ҵ�
            if (gameManager != null)
            {
                GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
                if (gameManagerScript != null)
                {
                    string PoscoFutureVariable = "PoscoFuture";
                    gameManagerScript.MedoPFPNL(PoscoFutureVariable, indicatorText, indicator1Text, gameManagerScript.PFweekValue);
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
