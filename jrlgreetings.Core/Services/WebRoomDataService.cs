using jrlgreetings.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace jrlgreetings.Core.Services
{
    public class WebRoomDataService : BaseRoomDataService
    {
        readonly HttpClient client;
        readonly string baseURL = "https://greetingsfromjrl.azurewebsites.net";
        public WebRoomDataService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 20480;
            client.BaseAddress = new Uri(baseURL);
        }

        public async override Task InitAsync()
        {
            Debug.WriteLine("In web init");

            try
            {
                string content = await client.GetStringAsync("/api/rooms").ConfigureAwait(false);
                List<Room> webRooms = JsonConvert.DeserializeObject<List<Room>>(content);

                foreach (Room webRoom in webRooms)
                {
                    rooms[webRoom.RoomNo] = webRoom;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("using local, exception " + ex.Message);
                makeLocalRooms();
            }

            setViewModels();
        }
    }
}
