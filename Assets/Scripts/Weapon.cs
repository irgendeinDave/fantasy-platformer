using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public enum WeaponType
    {
        Axe,
        Wand,
        Sword,
        Spear,
        Bow
    }
    
    // Default damage for different weapon types
    // other modifiers should be defined in CharacterRole
    private Dictionary<WeaponType, float> WeaponDamage = new Dictionary<WeaponType, float>()
    {
        { WeaponType.Axe, 35f },
        { WeaponType.Wand, 15f },
        { WeaponType.Sword , 25 },
        { WeaponType.Spear, 20 },
        { WeaponType.Bow, 10f }
    };

    public float GetWeaponDamage(WeaponType type)
    {
        float val;
        if (!WeaponDamage.TryGetValue(type, out val))
        {
            Debug.LogError($"No Value found");
            return 0;
        }
        Debug.Log($"damage: {val.ToString()}");
        return val;
    }

}
