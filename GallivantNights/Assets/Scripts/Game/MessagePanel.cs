using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour {

    public GameObject messagePanel;
    public GameObject backgroundObject;
    public Button messageBtn_A;
    public Button messageBtn_B;
    public Image messageImage;
    public Text messageText;
    private Canvas currentCanvas;

    void Awake() {
        Refresh();
        currentCanvas = GetComponent<Canvas>();
    }

    public void Refresh() {
        messagePanel.SetActive(false);
        messageBtn_A.gameObject.SetActive(false);
        messageBtn_B.gameObject.SetActive(false);
        messageText.gameObject.SetActive(false);
        if (messageImage != null) {
            messageImage.gameObject.SetActive(false);
        }
    }

    public void CreateMessagePanel(UnityAction btn_action_A, UnityAction btn_action_B, Color bg_stroke, Color bg_color, string txt) {
        messagePanel = Instantiate<GameObject>(messagePanel);//0/ instantiates the panel
        messagePanel.transform.SetParent(currentCanvas.transform, false);//1/ Set to Canvas         
        messagePanel.GetComponent<Image>().color = bg_stroke;//2/ Set Panel Outline and Background
        backgroundObject.GetComponent<Image>().color = bg_color;
        messagePanel.transform.SetAsLastSibling();
        messagePanel.SetActive(true);
    }
}