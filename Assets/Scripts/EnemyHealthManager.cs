using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    private PlayerStats thePlayerStats;

    public int experienceToGive;

    // Use this for initialization
    void Start () {
        enemyCurrentHealth = enemyMaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update () {
        if (enemyCurrentHealth <= 0) {
            Destroy(gameObject);

            thePlayerStats.AddExperience(experienceToGive);
        }
    }

    public void HurtEnemy(int damageToGive) {
        enemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth() {
        enemyCurrentHealth = enemyMaxHealth;
    }
}
