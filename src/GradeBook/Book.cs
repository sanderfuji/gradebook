using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                
                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}!");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for(int index = 0; index < grades.Count; index += 1)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.00:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.00:
                    result.Letter = 'B';
                    break;
                
                case var d when d >= 70.00:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.00:
                    result.Letter = 'A';
                    break;

                default:
                    result.Letter = 'D';
                    break;
            }

            return result;
        }

        private List<double> grades;
        public string Name;
    }
}