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
        Console.WriteLine("Введи ник, кому необходимо отправить сообщение:");
        string username = Console.ReadLine();
        var resolved = await client.Contacts_ResolveUsername(username); // никнейм без @
        Console.Write("Введите через сколько минут отправить сообщение, например - 40"); // в минутах
        string time = Console.ReadLine();
        DateTime when = DateTime.UtcNow.AddMinutes(Convert.ToInt32(time));
        Console.WriteLine("Введите текст, который хотите отправить:");
        string messagetext = Console.ReadLine();
        client.SendMessageAsync(resolved, messagetext, schedule_date: when).GetAwaiter().GetResult();
    }
    public static Task SomeSendScheduleMessage(Client client) // Запланировать отправку нескольких уведомлений
    {
        Console.WriteLine("Введи ник, кому необходимо отправить сообщение:");
        string username = Console.ReadLine();
        var resolved = client.Contacts_ResolveUsername(username).GetAwaiter().GetResult(); // никнейм без @
        Console.Write("Введите интервал сообщений, например - 1440\n"); // в минутах
        string time = Console.ReadLine();
        DateTime when = DateTime.UtcNow.AddMinutes(Convert.ToInt32(time));
        Console.Write("Введите текст, который хотите отправить:");
        string messagetext = Console.ReadLine();
        Console.Write("Введите сколько раз вы хотите отправить сообщение:");
        string howmanytimes = Console.ReadLine();
        int howmany = Convert.ToInt32(howmanytimes);
        for (int i = 0; i < howmany; i++)
        {
            client.SendMessageAsync(resolved, messagetext, schedule_date: when).GetAwaiter().GetResult();
            when = when.AddMinutes(Convert.ToInt32(time));
        }
        return Task.CompletedTask;
    }
}

