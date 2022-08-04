
static int[] RandomArray(){
    
    int[] numbers = new int[10];
    Random rand = new Random();


    for(int i = 0; i < 10; i++){
        
        numbers[i] = rand.Next(5,25);
        Console.WriteLine(numbers[i]);
    }
    
    int  max, min;
    min = numbers[0];  
    max = numbers[0];  

    int sum = numbers.Sum(); 
    

    Console.WriteLine($"this is the sum {sum}");
    Console.WriteLine($"this is the max number " + numbers.Max());
    Console.WriteLine($"this is the min number " + numbers.Min());
    return numbers; 
    
}
RandomArray();


static string TossCoin(){

    Console.WriteLine("Tossing a Coin!"); 
    Random rand = new Random();

    int number = rand.Next(2); 
    

    if(number == 0){
        Console.WriteLine("Heads"); 
    }
    else
    { 
        Console.WriteLine("Tails");
    }
    return $"{number}";
}
TossCoin(); 


static string friends(){
    List<string> Names = new List<string>(){
    "Todd",
    "Tiffany",
    "Charlie",
    "Geneva",
    "Sydney",
    };


    foreach (string Name in Names){
        if(Name.Length > 5){
            Console.WriteLine($"{Name}");
        }
    }
    return string.Empty; 
    
    
    

}
friends();
