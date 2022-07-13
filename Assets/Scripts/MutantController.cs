using UnityEngine;

public class MutantController : MonoBehaviour
{
    [SerializeField] private MutantSettings settings;
    [SerializeField] private CreatureAnimator mutantAnimator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MutantHealthBar mutantHealth;

    private GameObject target;
    private float movementSpeed;
    private bool isAlive = true;

    public MutantDestructable mutantDestructable;
    public Damager damager;

    public GameObject Target { get => target; set => target = value; }
  

    private void Awake()
    {
        mutantDestructable.OnDie += StopMooving;
        mutantDestructable.OnMutantHealth += ShowHealth;
        damager.Damage = settings.damage;
    }

    void Update()
    {
        if (isAlive)
        {
            CheckDistance();
            MutantMove();
        }
        mutantHealth.RotateHealthBar();
    }

    public void RepeatInit(bool _isDie)
    {
        isAlive = true;
        mutantDestructable.IsDie = _isDie;
        mutantDestructable.Health++;
        mutantHealth.SetMaxHealth(mutantDestructable.Health);
    }
    private void MutantMove()
    {
        var step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);

        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
    }
    private void CheckDistance()
    {
        var heading = Target.transform.position - transform.position;
        var distance = heading.magnitude;

        if (distance <= settings.attackDistance)
        {
            movementSpeed = 0;
        }
        else
        {
            movementSpeed = settings.speed;
        }
        mutantAnimator.Run(movementSpeed);
    }
    private void StopMooving()
    {
        isAlive = false;
    }
    private void ShowHealth(int health)
    {
        mutantHealth.SetHealth(health);
    }
}
