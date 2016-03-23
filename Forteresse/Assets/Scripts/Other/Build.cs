using UnityEngine;
using System.Collections;


public class Build : MonoBehaviour
{
    public GameObject[] Tower;
    private Vector3 spawnPoints;
    bool canBuild = false;
    string name = "";
    int type;
    Attack monScript;

    void Start()
    {

    }
    void Update()
    {

        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        //Déclaration variables
        Tower = GameObject.FindGameObjectsWithTag("Tower");
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
            if (Physics.Raycast(transform.position, transform.forward * 10, out hit))
            {
                if (hit.collider.gameObject.tag == "Tower" && hit.distance <= 10)
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        //Instanciation d'un model de tour pour visualisation
        if (Input.GetKey(KeyCode.Alpha1) && !canBuild)
        {
            RaycastHit hit;
            name = "Mage Tower";
            type = 0;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                canBuild = true;
                StartCoroutine(spawnEnemy());
            }
        }

        if (Input.GetKey(KeyCode.Alpha2) && !canBuild)
        {
            RaycastHit hit;
            name = "Canon Tower";
            type = 1;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                canBuild = true;
                StartCoroutine(spawnEnemy());
            }
        }

        //l'objet suit la souris
        if (canBuild)
        {
            var player = GameObject.Find("Player");
            var tour = GameObject.Find(name + "(Clone)");

            double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180);
            double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);

            monScript = GameObject.Find(name + "(Clone)").GetComponent<Attack>();
            monScript.enabled = false;

            Vector3 playerPos = player.transform.position;
            Vector3 towerPos = tour.transform.position;

            tour.GetComponent<Collider>().enabled = false;
            Cursor.visible = false;

            tour.transform.position = new Vector3(playerPos.x + 20 * (float)sinAngle, 0, playerPos.z + 20 * (float)cosAngle);




            var walls = GameObject.Find("/" + name + "(Clone)/Walls");

            if (playerPos.x - towerPos.x > 50 || playerPos.x - towerPos.x < -50 || playerPos.z - towerPos.z > 50 || playerPos.z - towerPos.z < -50)
            {
                walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
            }
            else
                walls.GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);


        }


        //l'objet est construit pour de vrai en jeu 
        if (canBuild)
        {
            var player = GameObject.Find("Player");
            var tour = GameObject.Find(name + "(Clone)");

            monScript.enabled = true;

            Vector3 playerPos = player.transform.position;
            Vector3 towerPos = tour.transform.position;

            if (Input.GetMouseButton(1))
            {
                Destroy(tour);
                Cursor.visible = true;
                canBuild = false;
            }
            if (Input.GetMouseButton(0) && !(playerPos.x - towerPos.x > 50 || playerPos.x - towerPos.x < -50 || playerPos.z - towerPos.z > 50 || playerPos.z - towerPos.z < -50))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    var walls = GameObject.Find("/" + name + "(Clone)/Walls");

                    tour.GetComponent<Collider>().enabled = true;
                    Cursor.visible = true;

                    walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    canBuild = false;
                }
                GameObject.Find(name + "(Clone)").name = name + "(Build)";
            }
        }
    }


    //Clone l'objet voulu
    IEnumerator spawnEnemy()
    {
        Instantiate(Tower[type], new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity).name = name + "(Clone)";
        CancelInvoke();
        yield return new WaitForSeconds(0);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tower" && GameObject.Find(name + "(Clone)"))
        {
            GameObject.Find(name + "(Clone)/Walls").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
        }
    }
}
