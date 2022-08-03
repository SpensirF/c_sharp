namespace human;
public class Ninja : Human
{
    
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    public Ninja(string name) : base(name){
        Dexterity = 175;
    }
    // Add a constructor to assign custom values to all fields
    public Ninja(string name, int strength, int intelligence, int dexterity, int health) 
    : base(name, strength, intelligence, dexterity, health ){
    }
    // Build Attack method
    public override int Attack(Human target)
    {
        Random rand = new Random();
        int min = rand.Next(1, 6);
        int damage= Dexterity * 5; 
        target.Health -= damage;
        if ( min == 2){
            target.Health -= 10;
        }
        return target.Health;
    }
    public void Steal(Human target)
    {
        target.Health -= -5;
        Health = Health + 5;
    }
}