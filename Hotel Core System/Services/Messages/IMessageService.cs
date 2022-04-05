using Hotel_Core_System.Models;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Messages
{
    public interface IMessageService
    {
        public Task<int> AddMessage(Message message);
        public Task<int> UpdateMessage(Message message);
    }
}
