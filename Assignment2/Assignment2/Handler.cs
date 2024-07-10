
using System.Collections.Generic;

namespace Assignment2
{
    public class Handler
    {
        private bool flag = true;
        private string effect;
        private List<Tuple<char, int>> gases;
        public List<LayerOfGas> layers;
        public List<IAtmosphere> atmospheres;
        public Handler(string effect, List<Tuple<char, int>> gases)
        {
            this.effect = effect;
            this.gases = gases;
            layers = new List<LayerOfGas>(gases.Count);
            atmospheres = new List<IAtmosphere>();
        }

        public void dataToObjects()
        {
            for(int i = 0; i < gases.Count; i++)
            {
                switch (gases[i].Item1) {
                    case 'Z':
                        layers.Add(new Ozone(gases[i].Item2));
                        Console.WriteLine("Z : " + gases[i].Item1);
                        break;
                    case 'X':
                        layers.Add(new Oxygon(gases[i].Item2));
                        break;
                        
                    case 'C':
                        layers.Add(new CarbonO2(gases[i].Item2));
                        break;
                    default:
                        Console.WriteLine("Wrong Gases Input");
                        break;
                }
            }

            for(int i = 0; i < effect.Length; i++)
            {
                switch (effect[i])
                {
                    case 'O':
                        atmospheres.Add(Other.Instance());
                        break;
                    case 'S':
                        atmospheres.Add(SunShine.Instance());
                        break;
                    case 'T':
                        atmospheres.Add(Thunderstorm.Instance());
                        break;
                    default:
                        Console.WriteLine("Wrong Atmosphere Input");
                        break;
                }
            }
        }



        public void StartEffects()
        {

            IAtmosphere eff;
            for(int i = 0; i < atmospheres.Count; i++)
            {
                eff = atmospheres[i];
                foreach(LayerOfGas layer in layers)
                {
                    layer.AtmospereicEffect(eff);
                }

                for (int j = 0; j < layers.Count; j++)
                {
                    if (layers[j].GetThickness() < 0.5)
                    {
                        double value = layers[j].GetThickness();
                        flag = MergeOrPerish(j, value);
                        layers.RemoveAt(j);
                        if (!flag) return; 
                    }
                }
            }
        }

        public void StartEffectInLoop()
        {
            int rounds = 0;
            do
            {
                Console.WriteLine("Round: " + rounds++);
                StartEffects();
                PrintGasesLayer();
            } while (flag);
        }

        public bool MergeOrPerish(int n, double value)
        {
            
            for(int i = 0; i < layers.Count; i++)
            {
                
                if (n != i && layers[i].GetGasType() == layers[n].GetGasType())
                //if (n != i && layers[i] == layers[n])
                {
                    Console.WriteLine("Merging");
                    layers[i].AddThickness(value);
                    return true;
                }
            }

            return false;
        }

        
        public void PrintGasesLayer()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                Console.WriteLine($"Gas : {layers[i].GetGasType()} - Thickness : {layers[i].GetThickness()}");
            }

            Console.WriteLine("\n");
        }
    }
}
