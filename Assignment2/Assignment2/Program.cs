using TextFile;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Input.txt";
            List<Tuple<char, int>> list = new List<Tuple<char, int>>();
            TextFileReader file = new TextFileReader(fileName);
            int NumberOfLayers;
            string str, effectingVeriables;
            NumberOfLayers = int.Parse(file.ReadLine());
            string[] strArr;
            for(int i = 0; i < NumberOfLayers; i++)
            {
                str = file.ReadLine();
                strArr = str.Split(" ");
                list.Add(new Tuple<char, int>((strArr[0]).ToCharArray()[0], int.Parse(strArr[1])));
            }
            effectingVeriables = file.ReadLine();


            Handler handleGases = new Handler(effectingVeriables, list);

            handleGases.dataToObjects();
            Console.WriteLine("Before the effects");
            handleGases.PrintGasesLayer();
            Console.WriteLine("Durring The Effects");
            handleGases.StartEffectInLoop();
            Console.WriteLine("After One Gas Completely Parished");
            handleGases.PrintGasesLayer();
        }
    }
}