
public interface IDestructable 
{
    int Health { get; set; }
    void Hit(int damage);
    void Die();

}
