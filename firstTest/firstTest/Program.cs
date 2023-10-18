using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

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

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Здраствуй, Олег.");
                    return;
                }
                if (message.Text.ToLower().Contains("картинка"))
                {
                    var foto = "https://i.artfile.me/wallpaper/18-03-2015/1920x1080/goroda-moskva--rossiya-kreml-moskva-noch-915260.jpg";
                    InputFileUrl inputOnlineFile = new(foto);
                    await botClient.SendPhotoAsync(message.Chat.Id, inputOnlineFile);
                }
                if (message.Text.ToLower().Contains("видео"))
                {
                    await botClient.SendVideoAsync(
                        message.Chat.Id,
                        video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
                        thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"),
                        supportsStreaming: true);
                }
                if (message.Text.ToLower().Contains("стикер"))
                {
                    await botClient.SendStickerAsync(
                        message.Chat.Id,
                        sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"));
                }
                if (message.Text.ToLower().Contains("кнопки"))
                {
                    var keyboard = new ReplyKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new KeyboardButton("Привет"),
                                new KeyboardButton("Картинка")
                            },
                            new[]
                            {
                                new KeyboardButton("Видео"),
                                new KeyboardButton("Стикер")
                            }
                        }
                        );
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Выберите одну из кнопок:",
                        replyMarkup: keyboard
                        );
                }
            }
        }

        static async Task Error(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            try
            {
                // Ваш код здесь
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}