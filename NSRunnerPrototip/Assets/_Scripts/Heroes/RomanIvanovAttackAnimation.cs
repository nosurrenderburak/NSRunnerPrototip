using UnityEngine;

public class RomanIvanovAttackAnimation : MonoBehaviour
{
    [SerializeField] private BlasterAttackController blasterAttackController;
    [SerializeField] private HeroCollider hattoriHeroCollider;
    [SerializeField] private HeroCollider henryHeroCollider;
    
    
    public void KillHeroes()
    {
        blasterAttackController.PlayDeathAnimation();
        if (hattoriHeroCollider.gameObject.activeSelf) hattoriHeroCollider.OnDie();
        if (henryHeroCollider.gameObject.activeSelf) henryHeroCollider.OnDie();
    }
}
