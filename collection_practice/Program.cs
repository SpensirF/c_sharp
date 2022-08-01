
List<int> Numslist = new List<int>(){
    0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
};

List<string> names = new List<string>{
    "Tim", "Martin", "Nikki", "Sara"
};

List<bool> tells = new List<bool>{
    true, false, true, false, true, false, true, false, true, false
};

List<string> flavors = new List<string>{
    "chocolate", "vanilla", "strawberry", "rocky road", "mint"
};

// Console.WriteLine(flavors.Count);
// foreach (string flavor in flavors){
// //     Console.WriteLine(flavor);
// }
Console.WriteLine(flavors[3]);
flavors.RemoveAt(3);
Console.WriteLine(flavors.Count);

Dictionary<string, string> createdDictionary = new Dictionary<string, string>(){
    {"Tim", "vanilla"}, {"Martin", "chocolate"}, {"Nikki", "mint"}, {"Sara", "Strawberry"},
};

foreach (KeyValuePair<string,string> entry in createdDictionary){
    Console.WriteLine(entry.Key + "-" + entry.Value);
}