
public class HealtSystem
{
    private int healt;
    private int healtMax;
    public HealtSystem(int healtMax)
    {
        this.healtMax = healtMax;
        healt = healtMax;
    }
    public int getHealt() { return healtMax; }

    public float getHealtProcent()
    {
        return (float)healt / healtMax;
    }
    public void Damege(int damageAmount)
    {
        healt -= damageAmount;
        if (healt < 0) healt = 0;
    }
    public void Heal(int healAmount)
    {
        healt += healAmount;
        if (healt > healtMax)
        {
            healt= healtMax;
        }
    }
}
