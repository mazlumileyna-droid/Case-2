using Case_2.Models;
using System.Text.Json;


namespace Case_2.Services.UserServ

    {

        public class JsonFileService
        {
            private readonly string _filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "Users.json");

            //  GET
            public List<User> GetAll()
            {
                if (!File.Exists(_filePath))
                    return new List<User>();

                var json = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<User>();

                return JsonSerializer.Deserialize<List<User>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters =
                        {
                        new System.Text.Json.Serialization.JsonStringEnumConverter()
                        }
                    }) ?? new List<User>();
            }

            //  SAVE
            public void SaveAll(List<User> users)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                {
                    new System.Text.Json.Serialization.JsonStringEnumConverter()
                }
                };

                var json = JsonSerializer.Serialize(users, options);

                File.WriteAllText(_filePath, json);
            }
        }
    }
