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
    float range;
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
        if (target == null) return;
        if((target.transform.position - this.transform.position).magnitude <= range){
            shooting_timer += Time.deltaTime;
                
            var aiming_direction = (target.transform.position - this.transform.position).normalized;
            aim.transform.position = this.transform.position + aiming_direction;

            if(shooting_timer >= shooting_cd){
                float dot = Vector2.Dot(transform.right, aiming_direction);
                dot = Mathf.Acos(dot);
                float angles = 180 - dot * 180 / Mathf.PI;
                var projectile_position = aim.transform.position;
                GameObject projectile = Instantiate(projectile_prefab, projectile_position, Quaternion.Euler(0, 0, angles));
                projectile.GetComponent<ArrowMovement>().setArrowMovement(aiming_direction, projectile_speed);
                shooting_timer = 0;
            }
        }
    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + (target.transform.position - this.transform.position).normalized * range);
        Gizmos.DrawWireSphere(transform.position, range);
    }
    

}
