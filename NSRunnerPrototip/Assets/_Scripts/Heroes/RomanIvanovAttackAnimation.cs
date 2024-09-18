using UnityEngine;

public class RomanIvanovAttackAnimation : MonoBehaviour
{
    [SerializeField] private BlasterAttackController blasterAttackController;
    [SerializeField] private HeroCollider hattoriHeroCollider;
    [SerializeField] private HeroCollider henryHeroCollider;
    [SerializeField] private HeroBufferBlaster katanaBlaster;
    [SerializeField] private HeroBufferBlaster henryBlaster;
    
    
    [SerializeField] private HeroBufferBlaster[] heroBufferBlasters;
    
    
    public void KillHeroes()
    {
        blasterAttackController.PlayDeathAnimation();
        if (hattoriHeroCollider.gameObject.activeSelf) hattoriHeroCollider.OnDie();
        if (henryHeroCollider.gameObject.activeSelf) henryHeroCollider.OnDie();
        if (katanaBlaster.gameObject.activeSelf) katanaBlaster.OnDie();
        if (henryBlaster.gameObject.activeSelf) henryBlaster.OnDie();
        
        for (var i = 0; i < heroBufferBlasters.Length; i++)
        {
            if (heroBufferBlasters[i].gameObject.activeSelf) heroBufferBlasters[i].OnDie();
        }
    }
}
