using UnityEngine;
using System.Collections;

public class fireTarget : MonoBehaviour
{

    private Transform target = null;
    Vector3 targetPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            return;
        }
        else if (target != null)
        {
            targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            GameObject currentFire = transform.GetChild(0).gameObject;
            if (!currentFire.activeInHierarchy)
            {
                Vector3 pos = currentFire.transform.localPosition;
                currentFire.SetActive(true);
                GameObject fire = Instantiate(currentFire);
                fire.transform.parent = transform;
                fire.transform.localPosition = pos;
                Destroy(transform.GetChild(0).gameObject);
                fire.transform.SetAsFirstSibling();
            }
            this.transform.LookAt(targetPos);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = null;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && target == null)
            target = other.transform;
    }
}
