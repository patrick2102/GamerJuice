using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    GameObject target;

    [SerializeField]
    GameObject aim;
    [SerializeField]
    GameObject projectile_prefab;
    [SerializeField]
    float projectile_speed;
    [SerializeField]
    float shooting_cd;
    float shooting_timer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Renderer>().isVisible){
            shooting_timer += Time.deltaTime;
            var aiming_direction = (target.transform.position - this.transform.position).normalized;
            var rotation = Vector3.Dot(Vector3.up, aiming_direction);
            aim.transform.position = this.transform.position + aiming_direction;
            

            if(shooting_timer >= shooting_cd){
                var projectile_position = aim.transform.position;
                GameObject projectile = Instantiate(projectile_prefab, projectile_position, Quaternion.AngleAxis(rotation, Vector3.up));
                projectile.GetComponent<ArrowMovement>().setArrowMovement(aiming_direction, projectile_speed);
                shooting_timer = 0;
            }
        }
    }

}
