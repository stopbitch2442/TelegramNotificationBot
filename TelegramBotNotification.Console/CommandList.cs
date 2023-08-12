using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WTelegram;

public enum Commands
{
    SendMessage,
    SomeSendMessage,
    SendScheduleMessage,
    SomeSendScheduleMessage
}
public class CommandList
{
    public static async Task ShowCommandList(Client client)
    {
        await Console.Out.WriteLineAsync("Введите номер команды, которую необходимо выполнить:");
        int count = 1;
        foreach (Commands command in Enum.GetValues(typeof(Commands)))
        {
            await Console.Out.WriteLineAsync($"{count} - {command.ToString()}");
            count++;
        }
        string strChoice = await Console.In.ReadLineAsync();
        int choice = Convert.ToInt32(strChoice);
        switch (choice)
        {
            case 1:
                NowSendMessage.SendMessage(client);
                break;
            case 2:
                NowSendMessage.SomeSendMessage(client);
                break;
            case 3:
                ScheduleMessage.SendScheduleMessage(client);
                break;
            case 4:
                ScheduleMessage.SomeSendScheduleMessage(client);
                break;
            default: Console.Out.WriteLine("Ввели неправильное значение");
                ShowCommandList(client);
                break;
        }
    }
}