using UnityEngine.UI;
using UnityEngine;

public class enemyNRJBar : MonoBehaviour
{

    public Slider enemyNRJslider;

    public void SetMaxEnemyNRJ(float enemyNRJ)
    {
        enemyNRJslider.maxValue = enemyNRJ;
        enemyNRJslider.value = enemyNRJ;
    }
    public void SetEnemyNRJValue(float enemyNRJ)

    {
        enemyNRJslider.value = enemyNRJ;
    }
}