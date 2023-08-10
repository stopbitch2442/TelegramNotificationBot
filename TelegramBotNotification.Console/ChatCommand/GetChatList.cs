using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using WTelegram;


public class GetChatList
{
    public static async Task GetChatListId(Client client) // Получить айди групп и чатов
    {
        var chats = await client.Messages_GetAllChats();
        foreach (var (id, chat) in chats.chats)
            if (chat.IsActive)
                await Console.Out.WriteLineAsync($"{id} : {chat}");
    }

    public static async Task GetChatListParticipants(Client client) // Получить участников групп и чатов по айди чата
    {
        await Console.Out.WriteLineAsync("Введите id чата, по которому вы хотите получить список участников:");
        var chats = await client.Messages_GetAllChats();
        string stringChatId = await Console.In.ReadLineAsync();
        int chatId = Convert.ToInt32(stringChatId);
        var channel = (Channel)chats.chats[chatId]; // айди канала который нам нужен для получения списка
        var participants = await client.Channels_GetAllParticipants(channel);
    }


}

