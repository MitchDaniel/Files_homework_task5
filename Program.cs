using System.Text;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string parth = @"C:\Users\Brill\Desktop\Source.txt";
            if (!File.Exists(parth))
            {
                throw new FileNotFoundException();
            }
            //string[] intString = new string[100000];
            //for (int i = 0; i < intString.Length; i++)
            //{
            //    intString[i] = random.Next(-100000, 100000).ToString();
            //}
            //File.WriteAllLines(parth, intString);
            string[] linesFromFile = File.ReadAllLines(parth);
            int[] ints = new int[linesFromFile.Length];
            List<string> PositiveList = new List<string>();
            List<string> NegativeList = new List<string>();
            List<string> TwoNumbersList = new List<string>();
            List<string> FiveNumbersList = new List<string>();
            for (int i = 0; i < linesFromFile.Length; i++)
            {
                ints[i] = Convert.ToInt32(linesFromFile[i]);
                if (ints[i] > 0) PositiveList.Add(ints[i].ToString());
                else if(ints[i] < 0) NegativeList.Add(ints[i].ToString());
                if (Math.Abs(ints[i]) > 9 && Math.Abs(ints[i]) < 100) TwoNumbersList.Add(ints[i].ToString());
                else if (Math.Abs(ints[i]) > 9999 && Math.Abs(ints[i]) < 100000) FiveNumbersList.Add(ints[i].ToString());
            }
            string PositiveNumbers = GetNewName(parth, "Positive numbers");
            string NegativeNumbers = GetNewName(parth, "Negative numbers");
            string TwoNumbers = GetNewName(parth, "Two numbers");
            string FiveNumbersNumbers = GetNewName(parth, "Five numbers");

            Console.WriteLine($"Positive numbers: {PositiveList.Count}");
            Console.WriteLine($"Negative numbers: {NegativeList.Count}");
            Console.WriteLine($"Two numbers: {TwoNumbersList.Count}");
            Console.WriteLine($"Five numbers: {FiveNumbersList.Count}");

            File.WriteAllLines(PositiveNumbers, PositiveList.ToArray());
            File.WriteAllLines(NegativeNumbers, NegativeList.ToArray());
            File.WriteAllLines(TwoNumbers, TwoNumbersList.ToArray());
            File.WriteAllLines(FiveNumbersNumbers, FiveNumbersList.ToArray());
        }
        static string GetNewName(string sourceParth, string newName)
        {
            string[] newTempName = sourceParth.Split('\\');
            StringBuilder sbForName = new StringBuilder();
            for (int i = 0; i < newTempName.Length - 1; i++)
            {
                sbForName.Append(newTempName[i] + '\\');
            }
            sbForName.Append(newName);
            sbForName.Append(".txt");
            return sbForName.ToString();
        }
    }
}
//Задание 5:
//В файле содержится 100000 целых чисел. Приложение должно проанализировать файл и отобразить статистику по нему:
//1. Количество положительных чисел
//2. Количество отрицательных чисел
//3. Количество двузначных чисел
//4. Количество пятизначных чисел
//Кроме этого, приложение должно создать файлы с этими числами (положительные, отрицательные и т. д.)