using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarManager : MonoBehaviour
{
    private CombatCharacter playerCC;
    private Vector3 basePos;
    SceneInfo sceneinfo;
    public float movespeed;

    public int posxwhenoutofcombat;
    void Start()
    {
        sceneinfo = GameObject.Find("GeneralManager").GetComponent<SceneInfo>();
        playerCC = GameObject.FindAnyObjectByType<CombatCharacter>();
        basePos = GetComponent<RectTransform>().position;
        GetComponent<RectTransform>().position = basePos + new Vector3(posxwhenoutofcombat, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponentInChildren<Slider>().value = playerCC.CurrentHP/playerCC.MaxHP;
        GetComponentInChildren<TextMeshProUGUI>().text = (int)playerCC.CurrentHP + "/"+playerCC.MaxHP;


        if (sceneinfo.incombat && GetComponent<RectTransform>().position.x <= basePos.x)
        {
            GetComponent<RectTransform>().position = GetComponent<RectTransform>().position + new Vector3(movespeed * Time.deltaTime, 0, 0);
        }
        if (!sceneinfo.incombat && GetComponent<RectTransform>().position.x >= basePos.x + posxwhenoutofcombat && playerCC.CurrentHP >= playerCC.MaxHP)
        {
            GetComponent<RectTransform>().position = GetComponent<RectTransform>().position - new Vector3(movespeed * Time.deltaTime, 0, 0);
        }
    }
}
