using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assignment2;

namespace Assignment2Tests
{
    [TestFixture]
    public class HandlerTests
    {
        [Test]
        public void TestDataToObjects_CorrectlyInitializesLayersAndAtmospheres()
        {
            
            string effect = "OST";
            var gases = new List<Tuple<char, int>>
            {
                new Tuple<char, int>('Z', 10),
                new Tuple<char, int>('X', 15),
                new Tuple<char, int>('C', 20)
            };
            Handler handler = new Handler(effect, gases);

            handler.dataToObjects();

          
            Assert.AreEqual(3, handler.GetLayers().Count);
            Assert.AreEqual(3, handler.GetAtmospheres().Count);
        }

        [Test]
        public void TestStartEffects_UpdatesThicknessCorrectly()
        {
            
            string effect = "OST";
            var gases = new List<Tuple<char, int>>
            {
                new Tuple<char, int>('Z', 10),
                new Tuple<char, int>('X', 15),
                new Tuple<char, int>('C', 20)
            };
            Handler handler = new Handler(effect, gases);
            handler.dataToObjects();

           
            handler.StartEffects();

            // Assert
            var layers = handler.GetLayers();
            Assert.AreEqual(9.5, layers[0].GetThickness()); 
            Assert.AreEqual(6.41, layers[1].GetThickness()); 
            Assert.AreEqual(19, layers[2].GetThickness()); 
        }

        [Test]
        public void TestMergeOrPerish_MergesWhenPossible()
        {
            
            var gases = new List<Tuple<char, int>>
            {
                new Tuple<char, int>('X', 1),
                new Tuple<char, int>('X', 2)
            };
            Handler handler = new Handler("O", gases);
            handler.dataToObjects();

            
            bool merged = handler.MergeOrPerish(0, 1);

          
            Assert.IsTrue(merged);
            Assert.AreEqual(1.0, handler.GetLayers()[0].GetThickness());
        }

        [Test]
        public void TestMergeOrPerish_ReturnsFalseWhenNoMerge()
        {
           
            var gases = new List<Tuple<char, int>>
            {
                new Tuple<char, int>('X', 1),
                new Tuple<char, int>('Z', 2)
            };
            Handler handler = new Handler("O", gases);
            handler.dataToObjects();

            
            bool merged = handler.MergeOrPerish(0, 1);

           
            Assert.IsFalse(merged);
        }

        [Test]
        public void TestStartEffectInLoop_StopsWhenGasPerishes()
        {
            
            var gases = new List<Tuple<char, int>>
            {
                new Tuple<char, int>('X', 2)
            };
            Handler handler = new Handler("OST", gases);
            handler.dataToObjects();

            
            handler.StartEffectInLoop();

           
            Assert.AreEqual(0, handler.GetLayers().Count);
        }
    }

    public static class HandlerExtensions
    {
        public static List<LayerOfGas> GetLayers(this Handler handler)
        {
            return handler.layers;
        }

        public static List<IAtmosphere> GetAtmospheres(this Handler handler)
        {
            return handler.atmospheres;
        }
    }
}
