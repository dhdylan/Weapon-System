using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats: MonoBehaviour
{
    public int CurrentHealth;
    public int CurrentArmor;    

    public void TakeDamage(int damage)
    {
        Debug.Log(CurrentHealth);
        if(CurrentArmor > 0)
        {
            CurrentArmor = CurrentArmor - damage;
            if(CurrentArmor < 0)
            {
                int excessDamage = -CurrentArmor;
                CurrentArmor = CurrentArmor - CurrentArmor;
                CurrentHealth = CurrentHealth - excessDamage;
            }
        }
        else
        {
            Debug.Log(damage + " damage taken");
            CurrentHealth = CurrentHealth - damage;
        }

        Debug.Log(CurrentHealth);

        if(CurrentHealth <= 0)
        {
            //kilt
            Debug.Log(this + "died");
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
