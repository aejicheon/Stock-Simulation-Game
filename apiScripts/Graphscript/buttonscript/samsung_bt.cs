using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class samsung_bt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Button ������Ʈ ��������
        Button button = GetComponent<Button>();

        // ��ư�� ������ �� ȣ���� �Լ� ����
        button.onClick.AddListener(ActivatesamsungScript);
    }

    // ��ư�� ������ �� ȣ��Ǵ� �Լ�
    void ActivatesamsungScript()
    {
        // ���� ī�޶󿡼� ecopro ��ũ��Ʈ ��������
        samsung samsungScript = Camera.main.GetComponent<samsung>();

        // ecopro ��ũ��Ʈ�� �����ϰ� ��Ȱ��ȭ ������ ��쿡�� Ȱ��ȭ
        if (samsungScript != null && !samsungScript.enabled)
        {
            samsungScript.enabled = true;
        }
    }
}
