using MyColors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSalePanel : MonoBehaviour
{
    [SerializeField] private Vector2[] anchorForColumns;

    [SerializeField] private Transform[] rows;

    [SerializeField] private EnemyInformation panelPrefab;


    [SerializeField] private InformationPanelsForSale[] panelInformationForSales;

    [SerializeField] private Shop shop;

    private EnemyInformation[] allEnemyPanels = new EnemyInformation[24]; 

    private void Start()
    {
        if (panelInformationForSales.Length > 0)
        {
            Spawn();
        }
        else
        {
            //Debug.Log("Нет информации о панелях ");
        }
        allEnemyPanels[shop.AllParametrs.SelectedEnemySkin].Icon.color = MyColor.Orange;
    }

    private void Spawn()
    {
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < anchorForColumns.Length; j++)
            {
                EnemyInformation panel = Instantiate(panelPrefab, rows[i]);
                panel.RectTransform.anchorMin = anchorForColumns[j];
                panel.RectTransform.anchorMax = anchorForColumns[j];
                panel.RectTransform.anchoredPosition = Vector3.zero;
                AddInformation(ref panel, i * anchorForColumns.Length + j);
            }
        }
    }

    private void AddInformation(ref EnemyInformation panel, int index)
    {
        allEnemyPanels[index] = panel;
        panel.SaleElement.SetActive(!shop.AllParametrs.OpenSkins[index]);
        panel.TextPrice.text = panelInformationForSales[index].Price.ToString();
        if (shop.AllParametrs.OpenSkins[index])
        {
            panel.Icon.sprite = panelInformationForSales[index].Icon;
        }

        panel.Button.onClick.AddListener(() =>
        {
            if (shop.AllParametrs.OpenSkins[index])
            {
                shop.SelectedSkins(index, allEnemyPanels);
            }
            else if (shop.AllParametrs.Crystal >= panelInformationForSales[index].Price)
            {
                shop.BuySkin(allEnemyPanels, panelInformationForSales[index], index);
            }
        });

        panel.Icon.SetNativeSize();
    }
}
