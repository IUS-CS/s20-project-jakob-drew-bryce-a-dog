using System;

namespace Samtec.OpticsVRTrainer.Utility
{
    public class ArrayHelper
    {
        public static T[] ShiftArray<T>(T[] array, T newNumber, int arraySize)
        {
            var shiftDestinationArray = new T[arraySize];

            Array.Copy(array, 1, shiftDestinationArray, 0, array.Length - 1);

            shiftDestinationArray[arraySize - 1] = newNumber;

            return shiftDestinationArray;
        }
    }
}