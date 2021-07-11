using UnityEngine;
using DG.Tweening;
using MyColors;

public class PlayerColorSwitch : MonoBehaviour
{
    public int IndexColor { get; private set; }
 
    private SpriteRenderer spriteRenderer;

    public static PlayerColorSwitch Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = MyColor.White;
        IndexColor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ScaleAnimation();
            SwitchColor();
        }
    }

    private void SwitchColor()
    {
        IndexColor++;
        LoopIndexColor();
        spriteRenderer.color = IndexColor == 0 ? MyColor.White : MyColor.Orange;
        //currentColor = (Colors)IndexColor;
    }

    private void LoopIndexColor()
    {
        if(IndexColor > 1)
        {
            IndexColor = 0;
        }
    }

    private void ScaleAnimation()
    {
        transform
            .DOScale(1.06f, 0.1f)
            .OnComplete(() =>
            {
                transform.DOScale(1f, 0.1f);
            });
    }
}
