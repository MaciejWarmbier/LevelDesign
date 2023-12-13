using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObejctWithDescription : MonoBehaviour
{
    [SerializeField] List<Outline> outlines;
    [SerializeField] string text;
    GameObject descriptionObj;
    TextMeshProUGUI description;
    [SerializeField] Color color;

    private bool isActive = false;

    private void Start()
    {
        descriptionObj = GameObject.Find("DescOutline");
        description = GameObject.Find("DescText").GetComponent<TextMeshProUGUI>();
    }

    public void ShowDescriptionSet()
    {
        if (!isActive)
        {
            descriptionObj.SetActive(true);
            description.text = text;
            descriptionObj.GetComponent<Image>().color = color;
            foreach (Outline outline in outlines)
            {
                outline.OutlineColor = new Color(color.r, color.g, color.b, 1);
            }

            isActive = true;
        }
    }

    public void StopDescriptionSet()
    {
        descriptionObj.SetActive(false);
        description.text = text;
        isActive = false;

        foreach (Outline outline in outlines)
        {
            outline.OutlineColor = new Color(color.r, color.g, color.b, 0);
        }
    }
}
