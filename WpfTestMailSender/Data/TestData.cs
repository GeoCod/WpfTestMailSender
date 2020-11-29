using System.Collections.Generic;
using System.Linq;
using WpfTestMailSender.Models;

namespace WpfTestMailSender.Data
{
    static class TestData
    {
        // Возвращение списка серверов без использования LINQ
        public static List<Server> Servers
        {
            get 
            {
                var result = new List<Server>();
                for(int i = 0; i < 10; i++)
                {
                    var server = new Server() { Address = $"address{i}", Port = 10000 + i };
                    result.Add(server);
                }
                return result;
            }
        }

        // Возвращение списка отправителей через LINQ
        public static List<Sender> Senders
        {
            get
            {
                return Enumerable.Range(0, 10).Select(i => new Sender() { Address = $"address{i}", Name = $"name {i}" }).ToList();
            }
        }
    }
}
