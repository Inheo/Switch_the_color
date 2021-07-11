using DG.Tweening;
using MyColors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Image fadePanel;
    [SerializeField] private Text crystalText;

    [SerializeField] private AudioSource buySound;
    public AllParametrs AllParametrs { get; private set; }

    private void Awake()
    {
        AllParametrs = new AllParametrs();
        AllParametrs = JsonUtility.FromJson<AllParametrs>(PlayerPrefs.GetString("allParametrs"));
        UpdateUI();
        FadeStart();
    }

    public void ClickPlay()
    {
        Click.Instance.Play();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateUI()
    {
        crystalText.text = AllParametrs.Crystal.ToString();
    }
    private void FadeStart()
    {
        fadePanel.DOFade(0f, 0.8f).From(1f);
    }
    public void SelectedSkins(int index, EnemyInformation[] allEnemyPanels, bool soundPlay = true)
    {
        if(soundPlay) ClickPlay();
        allEnemyPanels[AllParametrs.SelectedEnemySkin].Icon.color = MyColor.White;
        allEnemyPanels[index].Icon.color = MyColor.Orange;
        AllParametrs.SelectedEnemySkin = index;
        AllParametrs.SaveAllParametrs(AllParametrs);
    }

    public void BuySkin(EnemyInformation[] allEnemyPanels, InformationPanelsForSale panelInformationForSale, int index)
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1) buySound.Play();

        AllParametrs.OpenSkins[index] = true;
        AllParametrs.Crystal -= panelInformationForSale.Price;
        allEnemyPanels[index].SaleElement.SetActive(!AllParametrs.OpenSkins[index]);
        allEnemyPanels[index].Icon.sprite = panelInformationForSale.Icon;
        allEnemyPanels[index].Icon.SetNativeSize();
        UpdateUI();
        SelectedSkins(index, allEnemyPanels, false);
    }
}
