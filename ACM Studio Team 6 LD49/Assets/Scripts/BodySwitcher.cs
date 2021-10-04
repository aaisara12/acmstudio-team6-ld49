using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySwitcher : MonoBehaviour
{
    [SerializeField] SpriteRenderer officeBody;
    [SerializeField] SpriteRenderer fantasyBody;


    void Start()
    {
        GameManager.instance.OnChangedGameMode += SetVariant;
        SetVariant(GameManager.instance.currentGameMode);
    }

    void OnDestroy()
    {
        GameManager.instance.OnChangedGameMode -= SetVariant;
    }

    void SetVariant(GameMode enemyVariant)
    {
        officeBody.enabled = enemyVariant == GameMode.OFFICE;
        fantasyBody.enabled = enemyVariant == GameMode.FANTASY;
    }
}
