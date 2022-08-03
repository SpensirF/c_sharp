namespace human;
public class Samurai : Human
{
    
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    public Samurai(string name) : base(name){
        Health = 200; 
    }
    // Add a constructor to assign custom values to all fields
    public Samurai(string name, int strength, int intelligence, int dexterity, int health) 
    : base(name, strength, intelligence, dexterity, health ){
    }
    // Build Attack method
    public override int Attack(Human target)
    {
        base.Attack(target);
        if(target.Health <= 50){
            target.Health = 0;
        }
        return target.Health;
    }
    public int Meditate(Human target)
    {
        target.Health += 200;
        return target.Health; 
    }
}