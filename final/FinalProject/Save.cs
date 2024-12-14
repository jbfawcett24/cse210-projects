using System.Text.Json;
class Save
{
    public static void SaveTask(List<Task> tasks, string type, string userName)
    {
        string baseFilePath = @$"../../../{userName}";
        string filePath = Path.Combine(baseFilePath, $"{type}.task");
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);
    }
    public static List<Task> LoadTask(string type, string userName)
    {
        string baseFilePath = @$"../../../{userName}";
        string filePath = Path.Combine(baseFilePath, $"{type}.task");
        string jsonFromFile = File.ReadAllText(filePath);
        List<Task> tasks = JsonSerializer.Deserialize<List<Task>>(jsonFromFile);
        return tasks;
    }
    public static void SavePet(Pet pet, string userName)
    {
        string filePath = @$"../../../{userName}/pet.pet";
        string json = JsonSerializer.Serialize(pet);
        File.WriteAllText(filePath, json);
    }
    public static Dog LoadPet(string userName)
    {
       string filePath = @$"../../../{userName}/pet.pet"; 
       string jsonFromFile = File.ReadAllText(filePath);
       Dog pet = JsonSerializer.Deserialize<Dog>(jsonFromFile);
       return pet;
    }
}