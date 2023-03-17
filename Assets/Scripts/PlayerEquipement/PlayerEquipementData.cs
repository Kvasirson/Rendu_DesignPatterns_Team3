using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerEquipementData", menuName = "ScriptableObjects/PlayerEquipementData")]
public class PlayerEquipementData : ScriptableObject
{
    #region Bonus Values
    
    [Header("Bonus Values")]

    [SerializeField]
    float m_bonusMoveSpeedMultiplier;

    [SerializeField]
    float m_bonusDamage;

    [SerializeField]
    float m_bonusHealth;

    #endregion

    #region Display
    [Header("Display")]

    [SerializeField]
    Sprite m_equipementSprite;

    #endregion

    #region Getters

    public float BonusMoveSpeed
    {
        get => m_bonusMoveSpeedMultiplier;
    }

    public float BonusDamage
    { 
        get => m_bonusDamage;
    }

    public float BonusHealth
    {
        get => m_bonusHealth;
    }

    public Sprite Sprite
    {
        get => m_equipementSprite;
    }

    #endregion
}
