namespace human;
public class Wizard : Human
{
    
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    public Wizard(string name) : base(name){
        Health = 50;
        Intelligence = 25; 
    }
    // Add a constructor to assign custom values to all fields
    public Wizard(string name, int strength, int intelligence, int dexterity, int health) 
    : base(name, strength, intelligence, dexterity, health ){
    }
    // Build Attack method
    public override int Attack(Human target)
    {
        int damage = Intelligence * 5; 
        target.Health -= damage;
        damage += Health; 
        return target.Health;
    }
    public int Heal(Human target)
    {
        target.Health += Intelligence * 10;
        return target.Health; 
    }
}