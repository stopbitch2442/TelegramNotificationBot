using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;

public class ScheduleMessage
{
    public static async Task SendScheduleMessage(Client client) // Запланировать отправку уведомления
    {
        await Console.Out.WriteLineAsync("Введи ник, кому необходимо отправить сообщение:");
        string username = await Console.In.ReadLineAsync();
        var resolved = await client.Contacts_ResolveUsername(username); // никнейм без @
        await Console.Out.WriteLineAsync("Введите через сколько минут отправить сообщение, например - 40"); // в минутах
        string time = await Console.In.ReadLineAsync();
        DateTime when = DateTime.UtcNow.AddMinutes(Convert.ToInt32(time));
        await Console.Out.WriteLineAsync("Введите текст, который хотите отправить:");
        string messagetext = await Console.In.ReadLineAsync();
        await client.SendMessageAsync(resolved, messagetext, schedule_date: when);
    }
    public static async Task SomeSendScheduleMessage(Client client) // Запланировать отправку нескольких уведомлений
    {
        await Console.Out.WriteLineAsync("Введи ник, кому необходимо отправить сообщение:");
        string username = await Console.In.ReadLineAsync();
        var resolved = await client.Contacts_ResolveUsername(username); // никнейм без @
        await Console.Out.WriteLineAsync("Введите интервал сообщений, например - 1440"); // в минутах
        string time = await Console.In.ReadLineAsync();
        DateTime when = DateTime.UtcNow.AddMinutes(Convert.ToInt32(time));
        await Console.Out.WriteLineAsync("Введите текст, который хотите отправить:");
        string messagetext = await Console.In.ReadLineAsync();
        await Console.Out.WriteLineAsync("Введите сколько раз вы хотите отправить сообщение:");
        string howmanytimes = await Console.In.ReadLineAsync();
        int howmany = Convert.ToInt32(howmanytimes);
        for (int i = 0; i < howmany; i++)
        {
            await client.SendMessageAsync(resolved, messagetext, schedule_date: when);
            when = when.AddMinutes(Convert.ToInt32(time));
        }
    }
}

