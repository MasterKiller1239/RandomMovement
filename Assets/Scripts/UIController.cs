using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthbar;
    [SerializeField]
    private TMP_Text Name;
    [SerializeField]
    private Button MarcoPoloButton;
    [SerializeField]
    private GameObject ScrollArea;
    private TMP_Text ScrollText;
    // Start is called before the first frame update
    void Start()
    {
        MarcoPoloButton.onClick.AddListener(delegate {
           MarcoPoloButtonClicked();
        });
        
        ScrollArea.SetActive(!ScrollArea.activeSelf);
    }

    private void MarcoPoloButtonClicked()
    {

        ScrollArea.SetActive(!ScrollArea.activeSelf);
        ScrollText = ScrollArea.transform.Find("TextContainer/TextArea").gameObject.GetComponent<TMP_Text>();
        
        for (int i = 1; i <= 100; i++)
        {
            string str = "";
            if (i % 3 == 0)
            {
                str += "Fizz";
            }
            if (i % 5 == 0)
            {
                str += "Buzz";
            }
            if (str.Length == 0)
            {
                str = i.ToString();
            }

            ScrollText.text += str +"\n";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
