using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 UserInput;
    public Controller cont;
    //Ability Bools
    public bool Slash;
    public bool Dash;
    public bool Flame;
    public bool Arrow;
    public bool Bard;
    public bool Trap;
    public bool Gravity;
    public bool AOEDamage;
    //AbilitySetToTrue Bools
    bool SlashSet = false;
    bool DashSet = false;
    bool FlameSet = false;
    bool ArrowSet = false;
    bool BardSet = false;
    bool TrapSet = false;
    bool GravitySet = false;
    bool AOEDamageSet = false;
    //Ability GameObjects
    public GameObject gOSlash;
    public GameObject gODash;
    public GameObject gOFlame;
    public GameObject gOArrow;
    public GameObject gOBard;
    public GameObject gOTrap;
    public GameObject gOAOEDamage;
    //What ability is currently selected
    public string randAbility;
    public int randomRangeList;
    public int randAbilityID;
    //List of acquired abilities
    public List<string> CurrentAbilities;
    //Flame variables
    float FlameTimer;
    //Dash variables
    public bool DashForceAdded = false;
    public float DashSpeed;
    public float DashTimer;
    void Start()
    {
        randomRangeList = CurrentAbilities.Count;
        randAbilityID = Random.Range(0, randomRangeList);
        randAbility = CurrentAbilities[randAbilityID];

    }

    // Update is called once per frame
    void Update()
    {
        UserInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        AddToList();
        if (Input.GetButtonDown("Ability"))
        {
            AbilityUse();
        }
        FlameTimer = FlameTimer + Time.deltaTime;
        //Disable Flame
        if (FlameTimer > 1.5)
        {
            gOFlame.GetComponent<SpriteRenderer>().enabled = false;
            gOFlame.GetComponent<Collider2D>().enabled = false;
        }
        //Stop Dash
        if (DashTimer < 0)
        {
            DashForceAdded = false;
            cont.movementEnabled = true;
            gODash.GetComponent<Collider2D>().enabled = false;
        }
        DashTimer = DashTimer - Time.deltaTime;
    }

    void AddToList()
    {
        if (Slash == true && SlashSet == false)
        {
            CurrentAbilities.Add("Slash");
            SlashSet = true;
        }
        if (Dash == true && DashSet == false)
        {
            CurrentAbilities.Add("Dash");
            DashSet = true;
        }
        if (Flame == true && FlameSet == false)
        {
            CurrentAbilities.Add("Flame");
            FlameSet = true;
        }
        if (Arrow == true && ArrowSet == false)
        {
            CurrentAbilities.Add("Arrow");
            ArrowSet = true;
        }
        if (Bard == true && BardSet == false)
        {
            CurrentAbilities.Add("Bard");
            BardSet = true;
        }
        if (Trap == true && TrapSet == false)
        {
            CurrentAbilities.Add("Trap");
            TrapSet = true;
        }
        if (Gravity == true && GravitySet == false)
        {
            CurrentAbilities.Add("Gravity");
            GravitySet = true;
        }
        if (AOEDamage == true && AOEDamageSet == false)
        {
            CurrentAbilities.Add("AOEDamage");
            AOEDamageSet = true;
        }
    }

    void AbilityUse()
    {
        if(randAbility == "Slash")
        {
            //SlashCode
        }
        else if (randAbility == "Dash")
        {
            rb.velocity = Vector2.zero;
            if (DashForceAdded == false)
            {
                DashTimer = 0.05f;
                rb.AddForce(new Vector2(UserInput.x * DashSpeed, UserInput.y * DashSpeed), ForceMode2D.Impulse);
                DashForceAdded = true;
                cont.movementEnabled = false;
                gODash.GetComponent<Collider2D>().enabled = true;
            }
        }
        else if (randAbility == "Flame")
        {
            gOFlame.GetComponent<SpriteRenderer>().enabled = true;
            gOFlame.GetComponent<Collider2D>().enabled = true;
            FlameTimer = 0;
        }
        else if (randAbility == "Arrow")
        {
            //ArrowCode
        }
        else if (randAbility == "Bard")
        {
            //BardCode
        }
        else if (randAbility == "Trap")
        {
            //TrapCode
        }
        else if (randAbility == "Gravity")
        {
            //GravityCode
        }
        else if (randAbility == "AOEDamage")
        {
            //AOEDamageCode
        }

        randomRangeList = CurrentAbilities.Count;
        randAbilityID = Random.Range(0, randomRangeList);
        randAbility = CurrentAbilities[randAbilityID];
    }
}
