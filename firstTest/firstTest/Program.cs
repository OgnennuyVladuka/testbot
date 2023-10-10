using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace firstTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("6359488045:AAEyUGIsCd_BIISoxiTMp2ZB4UpCPXsGm5c");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botclient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                if (message.Text.ToLower().Contains("привет"))
                {
                    await botclient.SendTextMessageAsync(message.Chat.Id, "Здраствуй, Олег.");
                    return;
                }
            }
        }

        private static Task Error(ITelegramBotClient botclient, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}