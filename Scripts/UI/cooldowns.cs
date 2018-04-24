using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class cooldowns : MonoBehaviour {

    public Image button1;
    public Image button2;
    public Image button3;
    public Image button4;
    public List<Skill> skills;
    public string spellUsed = "none";
    void FixedUpdate()
    {
        if (spellUsed == "teleport")
        {
            if (skills[0].currentCooldown >= skills[0].cooldown)
            {
                skills[0].currentCooldown = 0;
                spellUsed = "none";
            }
        }
        else if (spellUsed == "knockback")
        {
            if (skills[1].currentCooldown >= skills[1].cooldown)
            {
                skills[1].currentCooldown = 0;
                spellUsed = "none";
            }
        }
        else if (spellUsed == "fireball")
        {
            if (skills[2].currentCooldown >= skills[2].cooldown)
            {
                skills[2].currentCooldown = 0;
                spellUsed = "none";
            }
        }
        else if (spellUsed == "lightningbolt")
        {
            if (skills[3].currentCooldown >= skills[3].cooldown)
            {
                skills[3].currentCooldown = 0;
                spellUsed = "none";
            }
        }


        if (Input.GetMouseButton(0))
        {
            button3.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }else
        {
            button3.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
        if (Input.GetMouseButton(1))
        {
            button4.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }
        else
        {
            button4.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
        if (Input.GetKey("1"))
        {
            button1.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }
        else
        {
            button1.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
        if (Input.GetKey("2"))
        {
            button2.GetComponent<CanvasRenderer>().SetAlpha(1f);
        }
        else
        {
            button2.GetComponent<CanvasRenderer>().SetAlpha(0f);
        }
    }
    void Update()
    {
        foreach (Skill s in skills)
        {
            
            if (s.currentCooldown < s.cooldown)
            {
                s.currentCooldown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCooldown / s.cooldown;
            }
        }
    }


    [System.Serializable]
    public class Skill
    {
        public float cooldown;
        public Image skillIcon;
        public float currentCooldown;
    }
	
}
