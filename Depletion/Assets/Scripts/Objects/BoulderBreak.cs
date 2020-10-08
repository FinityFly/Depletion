using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBreak : MonoBehaviour
{
    public int breakStage = 0;
    private Sprite boulder1, boulder2, boulder3, boulder4;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        boulder1 = Resources.Load<Sprite>("Boulder/boulder1");
        boulder2 = Resources.Load<Sprite>("Boulder/boulder2");
        boulder3 = Resources.Load<Sprite>("Boulder/boulder3");
        boulder4 = Resources.Load<Sprite>("Boulder/boulder4");
    }

    // Update is called once per frame
    void Update()
    {
        switch (breakStage) {
            case 0:
                spriteRenderer.sprite = boulder1;
                break;
            case 1:
                spriteRenderer.sprite = boulder2;
                break;
            case 2:
                spriteRenderer.sprite = boulder3;
                break;
            case 3:
                spriteRenderer.sprite = boulder4;
                break;
            case 4:
                Destroy(gameObject);
                break;
        }
    }
}
