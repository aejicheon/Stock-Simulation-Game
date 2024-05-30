using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ecopro_bt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Button ������Ʈ ��������
        Button button = GetComponent<Button>();

        // ��ư�� ������ �� ȣ���� �Լ� ����
        button.onClick.AddListener(ActivateEcoproScript);
    }

    // ��ư�� ������ �� ȣ��Ǵ� �Լ�
    void ActivateEcoproScript()
    {
        // ���� ī�޶󿡼� ecopro ��ũ��Ʈ ��������
        ecopro ecoproScript = Camera.main.GetComponent<ecopro>();

        // ecopro ��ũ��Ʈ�� �����ϰ� ��Ȱ��ȭ ������ ��쿡�� Ȱ��ȭ
        if (ecoproScript != null && !ecoproScript.enabled)
        {
            ecoproScript.enabled = true;
        }
       
    }
}
