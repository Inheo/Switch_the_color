using UnityEngine;
using MyColors;

public class Enemy : MonoBehaviour
{
    public int IndexColor { get; private set; }
    public Color Color => spriteRenderer.color;

    [SerializeField] private Sprite[] enemySkins;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        IndexColor = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = enemySkins[Game.Instance.AllParametrs.SelectedEnemySkin];
    }

    private void OnEnable()
    {
        SetColor();
    }

    public void SetColor()
    {
        IndexColor = Random.Range(0, 2);

        spriteRenderer.color = IndexColor == 0 ? MyColor.White : MyColor.Orange;
    }
}
