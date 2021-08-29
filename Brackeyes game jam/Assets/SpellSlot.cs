using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpellSlot : MonoBehaviour
{
    public AbilityManager AbMan;
    public Sprite Slash;
    public Sprite Dash;
    public Sprite Flame;
    public Sprite Arrow;
    public Sprite Bard;
    public Sprite Trap;
    public Sprite Gravity;
    public Sprite Bomb;
    public SpriteRenderer SpriteRend;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AbMan.randAbility == "Slash")
        {
            SpriteRend.sprite = Slash;
        }
        else if (AbMan.randAbility == "Dash")
        {
            SpriteRend.sprite = Dash;
        }
        else if (AbMan.randAbility == "Flame")
        {
            SpriteRend.sprite = Flame;
        }
        else if (AbMan.randAbility == "Arrow")
        {
            SpriteRend.sprite = Arrow;
        }
        else if (AbMan.randAbility == "Bard")
        {
            SpriteRend.sprite = Bard;   
        }
        else if (AbMan.randAbility == "Trap")
        {
            SpriteRend.sprite = Trap;
        }
        else if (AbMan.randAbility == "Gravity")
        {
            SpriteRend.sprite = Gravity;
        }
        else if (AbMan.randAbility == "Bomb")
        {
            SpriteRend.sprite = Bomb;
        }
    }
}
