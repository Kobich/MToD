using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LabWorkTests
{
    // Тесты для функции StringToInt

    [TestMethod]
    public void Test_StringToInt_Binary()
    {
        // Arrange
        string input = "1101";
        int baseSystem = 2;
        int expected = 13;

        // Act
        int actual = LabWork.StringToInt(input, baseSystem);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_StringToInt_Octal()
    {
        // Arrange
        string input = "17";
        int baseSystem = 8;
        int expected = 15;

        // Act
        int actual = LabWork.StringToInt(input, baseSystem);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_StringToInt_Hexadecimal()
    {
        // Arrange
        string input = "1A";
        int baseSystem = 16;
        int expected = 26;

        // Act
        int actual = LabWork.StringToInt(input, baseSystem);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_StringToInt_Decimal()
    {
        // Arrange
        string input = "12345";
        int baseSystem = 10;
        int expected = 12345;

        // Act
        int actual = LabWork.StringToInt(input, baseSystem);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_StringToInt_InvalidCharacter()
    {
        // Arrange
        string input = "12G";
        int baseSystem = 16;

        // Act
        LabWork.StringToInt(input, baseSystem);

        // Assert: Expected exception
    }

    // Тесты для функции MaxValueAndIndex

    [TestMethod]
    public void Test_MaxValueAndIndex_NormalArray()
    {
        // Arrange
        int[] array = { 1, 3, 7, 2, 9, 5 };
        int expectedMaxValue = 9;
        int expectedMaxIndex = 4;

        // Act
        var (maxValue, maxIndex) = LabWork.MaxValueAndIndex(array);

        // Assert
        Assert.AreEqual(expectedMaxValue, maxValue);
        Assert.AreEqual(expectedMaxIndex, maxIndex);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_MaxValueAndIndex_EmptyArray()
    {
        // Arrange
        int[] array = { };

        // Act
        LabWork.MaxValueAndIndex(array);

        // Assert: Expected exception
    }

    [TestMethod]
    public void Test_MaxValueAndIndex_NegativeValues()
    {
        // Arrange
        int[] array = { -1, -3, -7, -2, -9, -5 };
        int expectedMaxValue = -1;
        int expectedMaxIndex = 0;

        // Act
        var (maxValue, maxIndex) = LabWork.MaxValueAndIndex(array);

        // Assert
        Assert.AreEqual(expectedMaxValue, maxValue);
        Assert.AreEqual(expectedMaxIndex, maxIndex);
    }

    [TestMethod]
    public void Test_MaxValueAndIndex_AllSameValues()
    {
        // Arrange
        int[] array = { 5, 5, 5, 5, 5 };
        int expectedMaxValue = 5;
        int expectedMaxIndex = 0;

        // Act
        var (maxValue, maxIndex) = LabWork.MaxValueAndIndex(array);

        // Assert
        Assert.AreEqual(expectedMaxValue, maxValue);
        Assert.AreEqual(expectedMaxIndex, maxIndex);
    }

    [TestMethod]
    public void Test_MaxValueAndIndex_LargeArray()
    {
        // Arrange
        int[] array = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            array[i] = i;
        }
        int expectedMaxValue = 999;
        int expectedMaxIndex = 999;

        // Act
        var (maxValue, maxIndex) = LabWork.MaxValueAndIndex(array);

        // Assert
        Assert.AreEqual(expectedMaxValue, maxValue);
        Assert.AreEqual(expectedMaxIndex, maxIndex);
    }

    // Тесты для функции MaxOddValueWithOddIndex

    [TestMethod]
    public void Test_MaxOddValueWithOddIndex_NormalArray()
    {
        // Arrange
        int[] array = { 2, 5, 6, 7, 8, 9 };
        int expectedMaxOddValue = 9;
        int expectedIndex = 5;

        // Act
        int index;
        int actualMaxOddValue = LabWork.MaxOddValueWithOddIndex(array, out index);

        // Assert
        Assert.AreEqual(expectedMaxOddValue, actualMaxOddValue);
        Assert.AreEqual(expectedIndex, index);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Test_MaxOddValueWithOddIndex_EmptyArray()
    {
        // Arrange
        int[] array = { };

        // Act
        LabWork.MaxOddValueWithOddIndex(array, out int index);

        // Assert: Expected exception
    }

    [TestMethod]
    public void Test_MaxOddValueWithOddIndex_NoOddValues()
    {
        // Arrange
        int[] array = { 2, 4, 6, 8, 10, 12 };
        int expectedMaxOddValue = 0;
        int expectedIndex = -1;

        // Act
        int index;
        int actualMaxOddValue = LabWork.MaxOddValueWithOddIndex(array, out index);

        // Assert
        Assert.AreEqual(expectedMaxOddValue, actualMaxOddValue);
        Assert.AreEqual(expectedIndex, index);
    }

    [TestMethod]
    public void Test_MaxOddValueWithOddIndex_OnlyOddIndexes()
    {
        // Arrange
        int[] array = { 1, 3, 1, 5, 1, 7 };
        int expectedMaxOddValue = 7;
        int expectedIndex = 5;

        // Act
        int index;
        int actualMaxOddValue = LabWork.MaxOddValueWithOddIndex(array, out index);

        // Assert
        Assert.AreEqual(expectedMaxOddValue, actualMaxOddValue);
        Assert.AreEqual(expectedIndex, index);
    }

    [TestMethod]
    public void Test_MaxOddValueWithOddIndex_MixedArray()
    {
        // Arrange
        int[] array = { 2, 15, 6, 3, 8, 7 };
        int expectedMaxOddValue = 15;
        int expectedIndex = 1;

        // Act
        int index;
        int actualMaxOddValue = LabWork.MaxOddValueWithOddIndex(array, out index);

        // Assert
        Assert.AreEqual(expectedMaxOddValue, actualMaxOddValue);
        Assert.AreEqual(expectedIndex, index);
    }
}
