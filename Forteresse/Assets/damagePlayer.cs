using UnityEngine;
using System.Collections;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 30;
    int damage = 10;

    public GameObject[] Proj;
    Vector3 sommet;

    void Start()
    {
        
    }

    void Update()
    {
        Proj = GameObject.FindGameObjectsWithTag("Damage");
    }


    /*public damagePlayer (int health)
    {
        this.playerHealth = health;
    }



    public int getHealth()
    {
        return this.playerHealth;
    }*/



    void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Damage")
        {
            var Proj = GameObject.Find("Projectile");
            playerHealth -= damage;
            print("enemyDong just touch..." + playerHealth);
        }
    }

    IEnumerator spawnProjectile(float x, float y, float z)
    {
        sommet.x = x;
        sommet.y = y;
        sommet.z = z;

        Instantiate(Proj[UnityEngine.Random.Range(0, Proj.Length - 1)], sommet, Quaternion.identity).name = "Projectile";
        CancelInvoke();
        yield return new WaitForSeconds(0);
    }
}
