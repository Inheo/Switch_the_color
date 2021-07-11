using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInformation : MonoBehaviour
{
    public bool isSale = true;

    [SerializeField] GameObject saleElement;
    [SerializeField] private Text textPrice;
    [SerializeField] private Image icon;
    [SerializeField] private Button button;
    [SerializeField] private RectTransform rectTransform;

    public GameObject SaleElement => saleElement;
    public Text TextPrice => textPrice;
    public Image Icon => icon;
    public Button Button => button;
    public RectTransform RectTransform => rectTransform;

}
