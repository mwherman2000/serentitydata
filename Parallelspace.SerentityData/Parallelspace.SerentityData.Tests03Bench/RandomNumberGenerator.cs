using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Parallelspace.SerentityData.Tests03Bench
{
    class RandomNumberGenerator
    {
        RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

        public RandomNumberGenerator() { }

        public int GetNextInt32()
        { return GetNextInt32(int.MinValue, int.MaxValue); }

        public int GetNextInt32(int low, int hi)
        { return (int)GetNextInt64(low, hi); }

        public long GetNextInt64()
        { return GetNextInt64(long.MinValue, long.MaxValue); }

        public long GetNextInt64(long low, long hi)
        {
            if (low >= hi)
                throw new ArgumentException("low must be < hi");
            byte[] buf = new byte[8];
            double num;

            //Generate a random double
            _rng.GetBytes(buf);
            num = Math.Abs(BitConverter.ToDouble(buf, 0));

            //We only use the decimal portion
            num = num - Math.Truncate(num);

            //Return a number within range
            return (long)(num * ((double)hi - (double)low) + low);
        }

        public double GetNextDouble()
        { return GetNextDouble(double.MinValue, double.MaxValue); }

        public double GetNextDouble(double low, double hi)
        {
            if (low >= hi)
                throw new ArgumentException("low must be < hi");
            byte[] buf = new byte[8];
            double num;

            //Generate a random double
            _rng.GetBytes(buf);
            num = Math.Abs(BitConverter.ToDouble(buf, 0));

            //We only use the decimal portion
            num = num - Math.Truncate(num);

            //Return a number within range
            return num * (hi - low) + low;
        }
    }
}
