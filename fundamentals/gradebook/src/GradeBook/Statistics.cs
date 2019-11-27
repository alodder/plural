using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';
                        
                    case var d when d >= 70.0:
                        return 'C';
                        
                    case var d when d >= 60.0:
                        return 'D';
                        
                    default:
                        return 'F';
                        
                }
            }
        }
        public double Sum;
        public int Count;

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            //Average = 0.0;
            Low = double.MaxValue;
            High = double.MinValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(Low, number);
            High = Math.Max(High, number);
        }
    }
}