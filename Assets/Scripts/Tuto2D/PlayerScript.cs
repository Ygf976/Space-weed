using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector3 speed = new Vector3(50, 0, 50);
    public float speedtouch = 0.03F;

    // 2 - Store the movement
    private Vector3 movement;


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");

        }
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        



        // 4 - Movement per direction
        movement = new Vector3(
          speed.x * inputX,
          0,
		  speed.z * inputZ);

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Careful: For Mac users, ctrl + arrow is a bad idea

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
                SoundEffectsHelper.Instance.MakePlayerShotSound();
            }
        }
       

        // End of the update method

    }

    void FixedUpdate()
    {
        // 7 - Move the game object
        GetComponent<Rigidbody>().velocity = movement;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
    void OnDestroy()
    {
        // Game Over.
        var gameOver = FindObjectOfType<GameOverScript>();
        gameOver.ShowButtons();
    }
}