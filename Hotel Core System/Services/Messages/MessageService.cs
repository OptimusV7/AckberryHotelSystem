using Hotel_Core_System.Models;
using Hotel_Core_System.Services.LogManagerConf;
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
            var mes = new Message
            {
                Message_txt = message.Message_txt,
                Recipient = message.Recipient,
            };
            _dbContext.Messages.Add(mes);
            var mess = _dbContext.Messages.FindAsync(message.Id);
            var mesStatus = new MessageStatus
            {
                Message_Status_Name = "Sent",
                MessageId = mess.Result.Id,
            };
            _dbContext.MessageStatuses.Add(mesStatus);

            var results = await _dbContext.SaveChangesAsync();
            if (results > 0)
            {
                _logger.LogInformation(results.ToString());
            }
            _logger.LogInformation(results.ToString());
            return 200;
        }

        public Task<int> UpdateMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}
