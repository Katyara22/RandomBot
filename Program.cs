using Discord;
using Discord.WebSocket;

namespace Discord_Rndom_Bot
{

    class Program
    {
        private static DiscordSocketClient client;

        static void Main(string[] args)
            => new Program () .MainAsync () .GetAwaiter () .GetResult ();

        private async Task MainAsync ()
        {
            client = new DiscordSocketClient ();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "OTc1MTAyMzY5Nzg2Mzg0NDY0.GTNyD9.SR9xdy-VTjJrMdonadgNYlNA1hJW1vdUgIoXa4";

            await client.LoginAsync (TokenType.Bot, token);
            await client.StartAsync ();

            Console.ReadLine ();
        }

        private Task Log (LogMessage msg)
        {
             Console.WriteLine(msg.ToString());
            return Task.CompletedTask; ;
        }

        private Task CommandsHandler (SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                switch (msg.Content)
                {   
                    case "!r":
                        {
                            Random rnd = new Random ();
                            msg.Channel.SendMessageAsync($"number rolled {rnd.Next(0, 64)}");
                            break;
                        }
                    case "!random":
                        {
                            Random rnd = new Random ();
                            msg.Channel.SendMessageAsync($"number rolled {rnd.Next(-1000, 1000)}");
                            break;
                        }
                }
            return Task.CompletedTask;
        }
    }
}   