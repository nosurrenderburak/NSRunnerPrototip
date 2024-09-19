using UnityEngine;

public class RomanIvanovAttackAnimation : MonoBehaviour
{
    [SerializeField] private BlasterAttackController blasterAttackController;
    [SerializeField] private HeroCollider hattoriHeroCollider;
    [SerializeField] private HeroCollider henryHeroCollider;
    [SerializeField] private HeroBufferBlaster katanaBlaster;
    [SerializeField] private HeroBufferBlaster henryBlaster;
    
    
    [SerializeField] private HeroBufferBlaster[] heroBufferBlasters;
    [SerializeField] private GameObject heliBody;
    [SerializeField] private GameObject revolverBody;
    [SerializeField] private ParticleSystem heliParticle;
    [SerializeField] private ParticleSystem revolverParticle;
    
    
    public void KillHeroes()
    {
        blasterAttackController.PlayDeathAnimation();
        if (hattoriHeroCollider != null) hattoriHeroCollider.OnDie();
        if (henryHeroCollider != null) henryHeroCollider.OnDie();
        if (katanaBlaster != null) katanaBlaster.OnDie();
        if (henryBlaster != null) henryBlaster.OnDie();
        
        /*
        for (var i = 0; i < heroBufferBlasters.Length; i++)
        {
            if (heroBufferBlasters[i].gameObject.activeSelf) heroBufferBlasters[i].OnDie();
        }
        h*/
        
        if (heliBody.activeSelf) heliBody.SetActive(false);
        if (revolverBody.activeSelf) revolverBody.SetActive(false);
        heliParticle.Play();
        revolverParticle.Play();
    }
}
