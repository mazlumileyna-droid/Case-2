using Case_2;

namespace Case_2.Registers
{
  
    public class RoomRegister // gemmer alle rooms
    {
        private List<Room> rooms = new List<Room>();

        public void Add(Room room)
        {
            rooms.Add(room);
        }

        public List<Room> GetAll()
        {
            return rooms;
        }
    }
}
