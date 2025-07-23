using MachineController.Objects;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Xml.Linq;

namespace MachineController.Functions
{
    public static class DatabaseFunctions
    {
        private static readonly string database = $"Data Source={Application.StartupPath}\\MachineController.sqlite";

        public static void ExecuteNonQueryWithSQL(string commandText)
        {
            try
            {
                using var connection = new SqliteConnection(database);
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public static void ExecuteQueryWithSQL(string commandText)
        {
            try
            {
                using var connection = new SqliteConnection(database);
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = commandText;
                using SqliteDataReader reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public static void CreateDatabase()
        {
            try
            {
                if (!File.Exists(database))
                {
                    using var connection = new SqliteConnection(database);
                    connection.Open();
                    string sql = @"
                        CREATE TABLE IF NOT EXISTS [settings] (
                            [name] TEXT PRIMARY KEY,
                            [value] TEXT
                        );
                        CREATE TABLE IF NOT EXISTS [library] (
                            [id] INTEGER PRIMARY KEY AUTOINCREMENT,
                            [filename] TEXT NOT NULL,
                            [filepath] TEXT NOT NULL,
                            [runtime] TEXT NOT NULL,
                            [materialused] TEXT NOT NULL
                        );
                        CREATE TABLE IF NOT EXISTS [gcodes] (
                            [id] INTEGER PRIMARY KEY AUTOINCREMENT,
                            [gcode] TEXT NOT NULL
                        );
                        CREATE TABLE IF NOT EXISTS [commands] (
                            [id] INTEGER PRIMARY KEY AUTOINCREMENT,
                            [type] TEXT NOT NULL,
                            [data] TEXT NOT NULL,
                            [timestamp] TEXT NOT NULL
                        );";
                    ExecuteNonQueryWithSQL(sql);
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public static List<string> GetGCodeCommands()
        {
            List<string> gcodeCommands = [];
            try
            {
                using var connection = new SqliteConnection(database);
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT [gcode] FROM [gcodes]";

                using SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        gcodeCommands.Add(reader.GetString(0));
                    }
                }
                return gcodeCommands;
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
                return gcodeCommands;
            }
        }

        public static void SetGCodeCommands(string gCode)
        {
            try
            {
                using var connection = new SqliteConnection(database);
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT [gcode] FROM [gcodes] WHERE [gcode] = '{gCode}'";

                using SqliteDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    ExecuteNonQueryWithSQL($"INSERT INTO [gcodes] ([gcode]) VALUES('{gCode}')");
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public static Setting GetSetting(string name, string value = "")
        {
            Setting setting = new();
            try
            {
                using var connection = new SqliteConnection(database);
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT [name], [value] FROM [settings] WHERE [name] = '{name}'";

                using SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        setting.Name = reader.GetString(0);
                        setting.Value = reader.GetString(1);
                    }
                }
                else
                {
                    // If the setting does not exist, create it with the provided value
                    setting.Name = name;
                    setting.Value = value;

                    ExecuteNonQueryWithSQL($"INSERT INTO [settings] ([name], [value]) VALUES('{name}', '{value}')");

                }
                return setting;
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
                return setting;
            }
        }

        public static void SetSetting(string name, string value) 
        {
            Setting setting = GetSetting(name);
            ExecuteNonQueryWithSQL($"UPDATE [settings] SET [value] = '{value}' WHERE [name] = '{name}'");
        }

        public static void CreateLibraryEntry(LibraryEntry libraryEntry)
        {
            try
            {
                string sql = @$"
                             INSERT INTO [library] ([filename], [filepath], [runtime], [materialused]) 
                             VALUES('{libraryEntry.FileName}', 
                                    '{libraryEntry.FilePath}', 
                                    '{libraryEntry.RunTime}', 
                                    '{libraryEntry.MaterialUsed}')";

                ExecuteNonQueryWithSQL(sql);

            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public static List<LibraryEntry> ReadAllLibraryEntries()
        {
            List<LibraryEntry> libraryEntryList = [];
            try
            {
                using var connection = new SqliteConnection(database);
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.CommandText = $@"SELECT * FROM [library]";

                using SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LibraryEntry libraryEntry = new()
                    {
                        Id = reader.GetInt32(0),
                        FileName = reader.GetString(1),
                        FilePath = reader.GetString(2),
                        RunTime = reader.GetString(3),
                        MaterialUsed = reader.GetString(4)
                    };
                    libraryEntryList.Add(libraryEntry);
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
            return libraryEntryList;
        }

        public static void DeleteLibraryEntry(int id)
        {
            try
            {
                ExecuteNonQueryWithSQL(@$"DELETE FROM [library] WHERE [id] = {id}");
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }
    }
}