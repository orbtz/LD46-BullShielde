using UnityEngine;

public class EscortLife: MonoBehaviour
{
    public int Life;
    public bool isDead = false;

    public EndState End;

    public void LoseLife(int removeValue)
    {
        Life = Life - removeValue;

        if (Life <= 0)
        {
            isDead = true;
            End.Die = true;
        }
    }

}
