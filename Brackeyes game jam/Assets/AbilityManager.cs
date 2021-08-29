using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 UserInput;
    public Controller cont;
    public Transform Rotator;
    //Enemy variables
    public bool isEnemy;
    public float enemyTimer;
    public GameObject Player;

    public float SpeedSave;
    public float AttackTimer;
    public Animator animate;
    public bool CastDone;
    //Ability Bools
    public bool Slash;
    public bool Dash;
    public bool Flame;
    public bool Arrow;
    public bool Bard;
    public bool Trap;
    public bool Gravity;
    public bool Bomb;
    //AbilitySetToTrue Bools
    bool SlashSet = false;
    bool DashSet = false;
    bool FlameSet = false;
    bool ArrowSet = false;
    bool BardSet = false;
    bool TrapSet = false;
    bool GravitySet = false;
    bool BombSet = false;
    //Ability GameObjects
    public GameObject gOSlash;
    public GameObject gODash;
    public GameObject gOFlame;
    public GameObject gOArrow;
    public GameObject gOBard;
    public GameObject gOTrap;
    public GameObject partGravity;
    public GameObject gOGravity;
    public GameObject gOBomb;
    //What ability is currently selected
    public string randAbility;
    public int randomRangeList;
    public int randAbilityID;
    //List of acquired abilities
    public List<string> CurrentAbilities;
    //Flame variables
    float FlameTimer;
    bool DoFlameTimer;
    //Slash variables
    float SlashTimer;
    //Dash variables
    public bool DashForceAdded = false;
    public float DashSpeed;
    public float DashTimer;
    //Arrow variables
    public GameObject ArrowSpawn;
    //Bard variables
    public float BardTimer;
    public bool DoTimer;
    //Gravity variables
    public float GravityTimer;
    void Start()
    {
        animate = GetComponent<Animator>();
    }
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (isEnemy == true)
        {
            int Ability = Random.Range(1, 8);
            if (Ability == 1)
            {
                Slash = true;
            }
            else if (Ability == 2)
            {
                Dash = true;
            }
            else if (Ability == 3)
            {
                Flame = true;
            }
            else if (Ability == 4)
            {
                Arrow = true;
            }
            else if (Ability == 5)
            {
                Bard = true;
            }
            else if (Ability == 6)
            {
                Trap = true;
            }
            else if (Ability == 7)
            {
                Gravity = true;
            }
            else if (Ability == 8)
            {
                Bomb = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CastDone == true)
        {
            animate.SetBool("Cast", false);
            CastDone = false;
        }
        if (isEnemy == false)
        {
            UserInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        AddToList();
        if (Input.GetButtonDown("Ability") && isEnemy == false && AttackTimer > 2.2)
        {
            AbilityUse();
            animate.SetBool("Cast", true);
            AttackTimer = 0;
        }else if(isEnemy == true && enemyTimer > 0)
        {
            AbilityUse();
            animate.SetBool("Cast", true);
            enemyTimer = Random.Range(-5.2f, -3);
        }
        FlameTimer = FlameTimer + Time.deltaTime;
        SlashTimer = SlashTimer + Time.deltaTime;
        BardTimer = BardTimer + Time.deltaTime;
        GravityTimer = GravityTimer + Time.deltaTime;
        enemyTimer = enemyTimer + Time.deltaTime;
        AttackTimer = AttackTimer + Time.deltaTime;
        //Disable Flame
        if (FlameTimer > 1.5 && DoFlameTimer == true)
        {
            gOFlame.GetComponent<SpriteRenderer>().enabled = false;
            gOFlame.GetComponent<Collider2D>().enabled = false;
            cont.MoveSpeed = SpeedSave;
            DoFlameTimer = false;
        }
        if (SlashTimer > 0.12)
        {
            gOSlash.GetComponent<SpriteRenderer>().enabled = false;
            gOSlash.GetComponent<Collider2D>().enabled = false;
        }
        if (BardTimer > 2 && DoTimer == true)
        {
            gOBard.GetComponent<SpriteRenderer>().enabled = false;
            gOBard.GetComponent<Collider2D>().enabled = false;
            cont.MoveSpeed = SpeedSave;
            DoTimer = false;
        }
        if (GravityTimer > 0.2)
        {
            gOGravity.GetComponent<Collider2D>().enabled = false;
        }
        //Stop Dash
        if (DashTimer < 0)
        {
            DashForceAdded = false;
            cont.movementEnabled = true;
            gODash.GetComponent<Collider2D>().enabled = false;
            gODash.GetComponent<SpriteRenderer>().enabled = false;
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
        if (Bomb == true && BombSet == false)
        {
            CurrentAbilities.Add("Bomb");
            BombSet = true;
        }
    }

    void AbilityUse()
    {
        if(randAbility == "Slash")
        {
            gOSlash.GetComponent<SpriteRenderer>().enabled = true;
            gOSlash.GetComponent<Collider2D>().enabled = true;
            SlashTimer = 0;
        }
        else if (randAbility == "Dash")
        {
            rb.velocity = Vector2.zero;
            if (DashForceAdded == false)
            {
                DashTimer = 0.05f;
                if (isEnemy == false)
                {
                    rb.AddForce(new Vector2(UserInput.x * DashSpeed, UserInput.y * DashSpeed), ForceMode2D.Impulse);
                    DashForceAdded = true;
                    cont.movementEnabled = false;
                    gODash.GetComponent<Collider2D>().enabled = true;
                    gODash.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    Vector3 dir = Player.transform.position - transform.position;
                    rb.AddForce(new Vector2(dir.x * DashSpeed, dir.y * DashSpeed), ForceMode2D.Impulse);
                    DashForceAdded = true;
                    cont.movementEnabled = false;
                    gODash.GetComponent<Collider2D>().enabled = true;
                    gODash.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        else if (randAbility == "Flame")
        {
            gOFlame.GetComponent<SpriteRenderer>().enabled = true;
            gOFlame.GetComponent<Collider2D>().enabled = true;
            FlameTimer = 0;
            cont.MoveSpeed = 0;
            rb.velocity = Vector2.zero;
            DoFlameTimer = true;
        }
        else if (randAbility == "Arrow")
        {
            Instantiate(gOArrow, ArrowSpawn.transform.position, Rotator.rotation, gameObject.transform);
        }
        else if (randAbility == "Bard")
        {
            gOBard.GetComponent<SpriteRenderer>().enabled = true;
            gOBard.GetComponent<Collider2D>().enabled = true;
            BardTimer = 0;
            cont.MoveSpeed = cont.MoveSpeed / 2;
            DoTimer = true;
        }
        else if (randAbility == "Trap")
        {
            Instantiate(gOTrap, ArrowSpawn.transform.position, Quaternion.identity);
        }
        else if (randAbility == "Gravity")
        {
            Instantiate(partGravity, transform);
            gOGravity.GetComponent<Collider2D>().enabled = true;
            GravityTimer = 0;
        }
        else if (randAbility == "Bomb")
        {
            Instantiate(gOBomb, transform.position, Quaternion.identity);
        }

        randomRangeList = CurrentAbilities.Count;
        randAbilityID = Random.Range(0, randomRangeList);
        randAbility = CurrentAbilities[randAbilityID];
    }
    public void SetCastFalse()
    {
        animate.SetBool("Cast", false);
    }
}
