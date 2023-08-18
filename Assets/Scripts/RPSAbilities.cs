using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSAbilities : MonoBehaviour
{
    public Text Letters;
    // Getting access to Speed attribute
    private PlayerMovement playerMovement;
    private RPSType rpsType;
    private Type playerType;
    [SerializeField] private float paperAcceleration = 2;
    [SerializeField] private float abilityCooldown = 10;
    [SerializeField] private float abilityDuration = 3;

    private bool abilityReady = true;

    public bool duringAbility = false;

    private float timer = 0.0f;
    private int seconds = 0;

    void Awake()
    {
        // Getting access to Speed attribute
        playerMovement = GetComponent<PlayerMovement>();

        // Getting access to Immortality attribute
        rpsType = GetComponent<RPSType>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerType = GetComponent<RPSType>().Type;
    }

    // Update is called once per frame
    void Update()
    {
        if (!abilityReady)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);

            Letters.text = "SKILL: " + (abilityCooldown - seconds) + "s";

            if(duringAbility)
            {
                Letters.text = "SKILL: ACTIVATED";
            }

            if (seconds >= abilityCooldown)
            {
                timer = 0.0f;
                seconds = 0;
                abilityReady = true;
                Letters.text = "SKILL: READY";
            }
        }

        if (duringAbility && seconds >= abilityDuration)
        {
            DeactivateSkill();
        }

        if (abilityReady && Input.GetKeyDown("space"))
        {
            ActivateSkill();
        }
    }

    private void ActivateSkill()
    {
        if (playerType == Type.Rock)
        {
            rpsType.immortality = true;
        }
        if (playerType == Type.Paper)
        {
            playerMovement.IncreaseSpeed(paperAcceleration);
        }
        abilityReady = false;
        duringAbility = true;
    }

    private void DeactivateSkill()
    {
        if (playerType == Type.Rock)
        {
            rpsType.immortality = false;
        }
        if (playerType == Type.Paper)
        {
            playerMovement.DecreaseSpeed(paperAcceleration);
        }
        timer = 0.0f;
        seconds = 0;
        duringAbility = false;
    }
}
