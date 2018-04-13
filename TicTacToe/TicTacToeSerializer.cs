using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using TicTacToe.GameState;

namespace TicTacToe
{
    public static class TicTacToeSerializer
    {
        public static string SerializeToJson(TicTacToeGame game)
        {
            var memoryStream = new MemoryStream();
            var settings = new DataContractJsonSerializerSettings
            {
                KnownTypes = new List<Type>
                {
                    typeof(GameInProgress),
                    typeof(GameForfeit),
                    typeof(GameDraw),
                    typeof(GameWon),
                },
                SerializeReadOnlyTypes = true
            };

            new DataContractJsonSerializer(typeof(TicTacToeGame), settings).WriteObject(memoryStream, game);
            memoryStream.Position = 0;

            return new StreamReader(memoryStream).ReadToEnd();
        }

        public static TicTacToeGame DeserializeJson(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }

            using (var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(jsonString ?? "")))
            {
                var settings = new DataContractJsonSerializerSettings
                {
                    KnownTypes = new List<Type>
                    {
                        typeof(GameInProgress),
                        typeof(GameDraw),
                        typeof(GameForfeit),
                        typeof(GameWon),
                    },

                    SerializeReadOnlyTypes = true
                };

                var ser = new DataContractJsonSerializer(typeof(TicTacToeGame), settings);
                ser.ReadObject(stream1);

                stream1.Position = 0;
                try
                {
                    return (TicTacToeGame) ser.ReadObject(stream1);
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }
    }
}