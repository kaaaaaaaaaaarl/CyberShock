using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthBar : MonoBehaviour
{
    public TMP_Text scores;
    public float cutPercentage = 0.4f;

    public SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    void Update()
    {
        if (cutPercentage > 0f && cutPercentage < 1f)
        {
            spriteRenderer.drawMode = SpriteDrawMode.Tiled;
            spriteRenderer.size = new Vector2(originalSprite.rect.width * (1f - cutPercentage), originalSprite.rect.height);
        }
        scores.text = MapValues.scorePoints.ToString();
    }
}