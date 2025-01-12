using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtsIconManager : MonoBehaviour
{
    private CombatCharacter combatcharacter;
    private SceneInfo sceneinfo;

    public int posywhenoutofcombat;
    public float movespeed;

    private Vector3 basePos;
    void Start()
    {
        sceneinfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
        combatcharacter = GameObject.FindFirstObjectByType<CombatCharacter>();
        foreach (Art art in combatcharacter.MoveIdList)
        {
            if (art.binding <= 4)
            {
                art.icon = transform.GetChild(art.binding - 1).gameObject;
                if (art.Sprite != null)
                {
                    art.icon.GetComponent<Image>().sprite = art.Sprite;
                }
                art.icon.GetComponentInChildren<TextMeshProUGUI>().text=art.name;

            }
        }
        basePos = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = basePos + new Vector3(0,posywhenoutofcombat, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Art art in combatcharacter.MoveIdList)
        {
            art.icon.transform.GetChild(0).GetComponent<Image>().fillAmount = art.cooldowncounter / (art.cooldown / Time.deltaTime);
            Color oldcolor = art.icon.transform.GetChild(0).GetComponent<Image>().color;
            Color newcolor = new Color(oldcolor.r, oldcolor.g, oldcolor.b, 0.1f + (200f / 255f) * (art.cooldowncounter / (art.cooldown / Time.deltaTime)));
            art.icon.transform.GetChild(0).GetComponent<Image>().color = newcolor;
            if(sceneinfo.focus!=null)
            {
                if (Vector3.Distance(combatcharacter.transform.position, sceneinfo.focus.transform.position) >= art.range)
                {
                    art.icon.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    art.icon.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else
            {
                art.icon.transform.GetChild(1).gameObject.SetActive(false);
            }
        }

        if(sceneinfo.incombat && GetComponent<RectTransform>().position.y<= basePos.y)
        {
            GetComponent<RectTransform>().position = GetComponent<RectTransform>().position + new Vector3(0, movespeed*Time.deltaTime, 0);
        }
        if (!sceneinfo.incombat && GetComponent<RectTransform>().position.y >= basePos.y + posywhenoutofcombat)
        {
            GetComponent<RectTransform>().position = GetComponent<RectTransform>().position - new Vector3(0, movespeed * Time.deltaTime, 0);
        }

    }
}
