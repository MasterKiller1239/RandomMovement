using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MarcoPolo
{
    public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject Unitinfo;
    [SerializeField]
    private Slider healthbar;
    [SerializeField]
    private TMP_Text Name;
    [SerializeField]
    private Button MarcoPoloButton;
    [SerializeField]
    private GameObject ScrollArea;
    private TMP_Text ScrollText;

    public GameObject currentUnit;
    // Start is called before the first frame update
    void Start()
    {
        MarcoPoloButton.onClick.AddListener(delegate {
           MarcoPoloButtonClicked();
        });
        
        ScrollArea.SetActive(!ScrollArea.activeSelf);
        Unitinfo.SetActive(!Unitinfo.activeSelf);

    }

    private void MarcoPoloButtonClicked()
    {

        ScrollArea.SetActive(!ScrollArea.activeSelf);
            if(ScrollArea.activeSelf)
            {
                ScrollText = ScrollArea.transform.Find("TextContainer/TextArea").gameObject.GetComponent<TMP_Text>();
                ScrollText.text = "";
                for (int i = 1; i <= 100; i++)
                {
                    string str = "";
                    if (i % 3 == 0)
                    {
                        str += "Marco";
                    }
                    if (i % 5 == 0)
                    {
                        str += "Polo";
                    }
                    if (str.Length == 0)
                    {
                        str = i.ToString();
                    }

                    ScrollText.text += str + "\n";
                }
            }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentUnit!=null)
        {
           
            Unitinfo.transform.Find("UnitName").gameObject.GetComponent<TMP_Text>().text = currentUnit.GetComponent<StatsComponent>().Name +"\n"+ currentUnit.GetComponent<StatsComponent>().CurrentHP + "/" + currentUnit.GetComponent<StatsComponent>().MaxHP;
            Unitinfo.transform.Find("Slider").gameObject.GetComponent<Slider>().value= currentUnit.GetComponent<StatsComponent>().CurrentHP/(float) currentUnit.GetComponent<StatsComponent>().MaxHP;
        }
        else
            Unitinfo.SetActive(false);
    }
    public void ShowInfoAboutUnit(GameObject unit)
    {
        Unitinfo.SetActive(!Unitinfo.activeSelf);
        currentUnit = unit;
    }
    public void HideInfoAboutUnit()
    {
        Unitinfo.SetActive(!Unitinfo.activeSelf);
        currentUnit = null;

    }

}
}