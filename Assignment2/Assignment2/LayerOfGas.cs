
namespace Assignment2
{
    public class LayerOfGas
    {
        protected double thickness;

        protected LayerOfGas(double thickness)
        {
            this.thickness = thickness;
        }

        protected void Effect(IAtmosphere effect, double otherEffect, double sunShineEffect, double thunderStormEffect)
        {
            switch (effect)
            {
                case Other:
                    this.thickness -= thickness * otherEffect;
                    break;
                case SunShine:
                    this.thickness -= thickness * sunShineEffect;
                    break;
                case Thunderstorm:
                    this.thickness -= thickness * thunderStormEffect;
                    break;
            }

            this.thickness = Math.Round(this.thickness, 2);
        }

        public void AscendGas(double value)
        {
            this.thickness += value;
        }

        public double GetThickness()
        {
            return thickness;
        }

        public void AddThickness(double value)
        {
            this.thickness += value;
        }
        public string GetGasType() {

            switch (this)
            {
                case Oxygon:
                    return "Oxygen";
                case CarbonO2:
                    return "Carbon Dioxide";
                case Ozone:
                    return "Ozone";
                default:
                    return "OtherGas";   
            }
        
        }
        public virtual void AtmospereicEffect(IAtmosphere effect) {}
    }

    public class Oxygon : LayerOfGas {
        private double otherEffect = 0.1;
        private double sunShineEffect = 0.05;
        private double thunderStormEffect = 0.5;
        private IAtmosphere atm;
        public Oxygon(double thickness) : base(thickness) { }

        public override void AtmospereicEffect(IAtmosphere effect) {

            Effect(effect, otherEffect, sunShineEffect, thunderStormEffect);

        }

    }
    
    public class Ozone : LayerOfGas {
        private double otherEffect = 0.05;
        private double sunShineEffect = 0.0;
        private double thunderStormEffect = 0.0;
        public Ozone(double thickness) : base(thickness) { }

        public override void AtmospereicEffect(IAtmosphere effect)
        {
            Effect(effect, otherEffect, sunShineEffect, thunderStormEffect);
        }

    }
    
    public class CarbonO2 : LayerOfGas {
        private double otherEffect = 0.0;
        private double sunShineEffect = 0.05;
        private double thunderStormEffect = 0.0;
        public CarbonO2(double thickness) : base(thickness) { }

        public override void AtmospereicEffect(IAtmosphere effect)
        {
            Effect(effect, otherEffect, sunShineEffect, thunderStormEffect);

        }

    }


}
