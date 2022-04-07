using Hotel_Core_System.Models;
using Hotel_Core_System.Services.LogManagerConf;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Core_System.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ILoggerManager _logger;
        public MessageService(ApplicationDBContext dBContext, ILoggerManager logger)
        {
            _dbContext = dBContext;
            _logger = logger;
        }
        public async Task<int> AddMessage(Message message)
        {           
            _dbContext.Messages.Add(message);           

            var results = await _dbContext.SaveChangesAsync();
            if (results > 0)
            {
                _logger.LogInformation(results.ToString());
                return (int)TaskStatus.RanToCompletion;
            }
            _logger.LogInformation(results.ToString());
            //return 200;
            return (int)TaskStatus.Faulted;
        }

        public async Task<int> AddMessageStatus(Message message)
        {
            var messageData = _dbContext.Messages.FirstOrDefault(x => x.Message_txt == message.Message_txt);
            var mesStatus = new MessageStatus
            {
                Message_Status_Name = "Sent",
                MessageId = messageData.Id,
            };
            _dbContext.MessageStatuses.Add(mesStatus);

            var results = await _dbContext.SaveChangesAsync();
            if (results > 0)
            {
                _logger.LogInformation(results.ToString());
                return (int)TaskStatus.RanToCompletion;
            }
            _logger.LogInformation(results.ToString());
            return (int)TaskStatus.Faulted;
        }

        public Task<int> UpdateMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}
