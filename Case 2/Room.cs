namespace Case_2
{
 
public class Room
{
    // properties
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int floor { get; set; }

    // contructor
    public Room(int id, string name, int capacity)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
    }
}
   
}
