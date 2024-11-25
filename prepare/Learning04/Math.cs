class Math : Assignment
{
    string textbookSection;
    string problems;
    public Math(string textbookSection, string problems, string studentName, string topic) : base(studentName, topic)
    {
        this.textbookSection = textbookSection;
        this.problems = problems;
    }
    public string GetHomeworkList()
    {
        return $"Section {textbookSection} Problems {problems}";
    }
}