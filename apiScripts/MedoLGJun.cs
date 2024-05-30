using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI; // Selector 스크립트에 접근하기 위한 네임스페이스

public class MedoLSJun : MonoBehaviour
{
    private Button yourButton;
    private GameObject gameManager;
    public Selector selector; // Selector 스크립트에 접근하기 위한 변수
    // Start is called before the first frame update
    void Start()
    {
        // 버튼을 코드로 찾습니다. 버튼의 이름이 "YourButton"인 경우
        yourButton = GameObject.Find("ButtonMedo").GetComponent<Button>();

        // 버튼에 클릭 이벤트 리스너를 추가합니다.
        yourButton.onClick.AddListener(TaskOnClick);

        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        //Debug.Log("버튼이 클릭되었습니다.");
        if (selector != null)
        {
            string indicatorText = selector.GetIndicator2Text(); //원
            string indicator1Text = selector.GetIndicator1Text(); //주

            // GameManager 스크립트에 접근하여 indicatorText 값을 TotalMoney Text UI 요소에 할당
            if (gameManager != null)
            {
                GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
                if (gameManagerScript != null)
                {
                    string LGjunVariable = "LGjun";
                    gameManagerScript.MedoLGJunPNL(LGjunVariable, indicatorText, indicator1Text, gameManagerScript.LGJunweekValue);
                }
                else
                {
                    //Debug.LogError("GameManager 스크립트를 찾을 수 없습니다.");
                }
            }
        }
        else
        {
            //Debug.LogError("Selector 스크립트를 찾을 수 없습니다.");
        }
    }
}
