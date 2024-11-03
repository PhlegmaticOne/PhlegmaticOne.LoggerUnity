using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors;
using OpenMyGame.LoggerUnity.Parameters.Log;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors.ViewConfig
{
    [TestFixture]
    public class ParameterColorsViewConfigDefaultTests
    {
        [Test]
        public void GetTagColor_ShouldReturnDefaultLogTextColor()
        {
            //Arrange
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var tagColor = viewConfig.GetTagColor("Tag");
            
            //Assert
            Assert.AreEqual(LoggerStaticData.DefaultLogTextColor, tagColor);
        }

        [Test]
        public void GetMessageParameterColor_ShouldReturnDefaultLogTextColor_WhenParameterTypeIsUnknown()
        {
            //Arrange
            var parameter = new { Value = 10 };
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var color = viewConfig.GetMessageParameterColor(parameter);
            
            //Assert
            Assert.AreEqual(LoggerStaticData.DefaultLogTextColor, color);
        }
        
        [Test]
        public void GetMessageParameterColor_ShouldReturnDefaultLogTextColor_WhenParameterIsNull()
        {
            //Arrange
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var color = viewConfig.GetMessageParameterColor(null);
            
            //Assert
            Assert.AreEqual(LoggerStaticData.DefaultLogTextColor, color);
        }
        
        [Test]
        public void GetMessageParameterColor_ShouldNotReturnDefaultLogTextColor_WhenParameterTypeIsString()
        {
            //Arrange
            const string parameter = "Test";
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var color = viewConfig.GetMessageParameterColor(parameter);
            
            //Assert
            Assert.AreNotEqual(LoggerStaticData.DefaultLogTextColor, color);
        }
        
        [Test]
        public void GetLogParameterColor_ShouldReturnDefaultLogTextColor_WhenParameterKeyIsEmptyString()
        {
            //Arrange
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var color = viewConfig.GetLogParameterColor("", null);
            
            //Assert
            Assert.AreEqual(LoggerStaticData.DefaultLogTextColor, color);
        }
        
        [Test]
        public void GetLogParameterColor_ShouldReturnDefaultLogTextColor_WhenParameterKeyIsUnknown()
        {
            //Arrange
            const string key = "RandomKey";
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var color = viewConfig.GetLogParameterColor(key, null);
            
            //Assert
            Assert.AreEqual(LoggerStaticData.DefaultLogTextColor, color);
        }
        
        [Test]
        public void GetLogParameterColor_ShouldNotReturnDefaultLogTextColor_WhenParameterKeyIsOneOfDefaultParameterKeys()
        {
            //Arrange
            var viewConfig = new ParameterColorsViewConfigDefault();

            //Act
            var color = viewConfig.GetLogParameterColor(LogFormatParameterThreadId.KeyParameter, null);
            
            //Assert
            Assert.AreNotEqual(LoggerStaticData.DefaultLogTextColor, color);
        }
    }
}