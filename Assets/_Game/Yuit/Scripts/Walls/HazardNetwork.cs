public class HazardNetwork : ObstacleNetwork, IHazardObject
{
    #region <====================| PROPERTIES |====================>
    
    public int damageDealth;
    
    #endregion <=============================================>
    
    #region <====================| MAIN HANDLE |====================>
    
    public override void TakeDamage(int damage)
    {
    }

    public int GetDamageDeal()
    {
        return damageDealth;
    }
    
    #endregion <=============================================>
}
