using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;


public class NowSendMessage
{
    public static void SendMessage(Client client) // Отправить сообщение
    {
        Console.WriteLine("Введи ник, кому необходимо отправить сообщение:");
        string username = Console.ReadLine();
        var resolved = client.Contacts_ResolveUsername(username).GetAwaiter().GetResult(); // никнейм без @
        Console.WriteLine("Введите текст, который хотите отправить:");
        string messagetext = Console.ReadLine();
        client.SendMessageAsync(resolved, messagetext).GetAwaiter().GetResult();
    }
    public static void SomeSendMessage(Client client) // Отправить несколько сообщений
    {
        Console.WriteLine("Введи ник, кому необходимо отправить сообщение:");
        string username = Console.ReadLine();
        var resolved = client.Contacts_ResolveUsername(username).GetAwaiter().GetResult(); // никнейм без @
        Console.WriteLine("Введите текст, который хотите отправить:");
        string messagetext = Console.ReadLine();
        Console.WriteLine("Введите сколько раз вы хотите отправить сообщение:");
        string howmanytimes = Console.ReadLine();
        int howmany = Convert.ToInt32(howmanytimes);
        for (int i = 0; i < howmany; i++)
        {
            client.SendMessageAsync(resolved, messagetext).GetAwaiter().GetResult();
        }
    }
}

