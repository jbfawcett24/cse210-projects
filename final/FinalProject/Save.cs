using System.Text.Json;
class Save
{
    public static void SaveTask(List<Task> tasks, string type)
    {
        string baseFilePath = @"../../../";
        string filePath = Path.Combine(baseFilePath, $"{type}.task");
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }
    public static List<Task> LoadTask(string type)
    {
        string baseFilePath = @"../../../";
        string filePath = Path.Combine(baseFilePath, $"{type}.task");
        string jsonFromFile = File.ReadAllText(filePath);
        List<Task> schoolTasks = JsonSerializer.Deserialize<List<Task>>(jsonFromFile);
        return schoolTasks;
    }
}