using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoBing.Shared.Data
{
    public class BoBingRoomsService
    {
        private readonly ConcurrentDictionary<string, BoBingRoom> boBingRooms = new();

        public bool TryGetRoom(string roomName, out BoBingRoom boBingRoom)
        {
            return boBingRooms.TryGetValue(roomName, out boBingRoom);
        }
        public BoBingRoom CreateRoom(BoBingRules rules, string name, string password)
        {
            BoBingRoom boBingRoom = new(rules, name, password);
            boBingRooms.TryAdd(boBingRoom.RoomName, boBingRoom);
            return boBingRoom;
        }
        public void DelectRoom(BoBingRoom boBingRoom)
        {
            boBingRooms.TryRemove(boBingRoom.RoomName, out boBingRoom);
        }
    }
}
