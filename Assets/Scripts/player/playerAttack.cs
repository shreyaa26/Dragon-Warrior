using UnityEngine;

public class playerAttack : MonoBehaviour
{
        [SerializeField] private float attackCooldown;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject[] fireballs;
        private Animator anim;
        private PlayerMovement PlayerMovement;
        private float cooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim= GetComponent<Animator>();
        PlayerMovement = GetComponent<PlayerMovement>();
    } 

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && PlayerMovement.canAttack())
            Attack();
        
        cooldownTimer += Time.deltaTime;  

    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++) {
            if(!fireballs[i].activeInHierarchy)
            return i;
        }
        return 0;
    }

}