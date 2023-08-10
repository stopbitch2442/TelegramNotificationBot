using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;


public class NowSendMessage
{
    public static async Task SendMessage(Client client) // Отправить сообщение
    {
        await Console.Out.WriteLineAsync("Введи ник, кому необходимо отправить сообщение:");
        string username = await Console.In.ReadLineAsync();
        var resolved = await client.Contacts_ResolveUsername(username); // никнейм без @
        await Console.Out.WriteLineAsync("Введите текст, который хотите отправить:");
        string messagetext = await Console.In.ReadLineAsync();
        await client.SendMessageAsync(resolved, messagetext);
    }
    public static async Task SomeSendMessage(Client client) // Отправить несколько сообщений
    {
        await Console.Out.WriteLineAsync("Введи ник, кому необходимо отправить сообщение:");
        string username = await Console.In.ReadLineAsync();
        var resolved = await client.Contacts_ResolveUsername(username); // никнейм без @
        await Console.Out.WriteLineAsync("Введите текст, который хотите отправить:");
        string messagetext = await Console.In.ReadLineAsync();
        await Console.Out.WriteLineAsync("Введите сколько раз вы хотите отправить сообщение:");
        string howmanytimes = await Console.In.ReadLineAsync();
        int howmany = Convert.ToInt32(howmanytimes);
        for (int i = 0; i < howmany; i++)
        {
            await client.SendMessageAsync(resolved, messagetext);
        }
    }
}

