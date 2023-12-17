﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    /// <summary>
    /// Class representing a polynomial
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Degree of this polynomial
        /// </summary>
        public int Degree
        {
            get
            {
                return Coefficients.Length - 1;
            }
        }

        /// <summary>
        /// Coefficients of this polynomial
        /// </summary>
        public double[] Coefficients { get; private set; }

        /// <summary>
        /// ValuesSet of this polynoamil
        /// </summary>
        public Interval? ValuesSet { get; private set; }


        /// <summary>
        /// Roots Of this polynomial
        /// </summary>
        public List<Root>? Roots {  get; private set; }

        /// <summary>
        /// Extreme values of this polynimial
        /// </summary>
        public List<Point>? ExtremeValues { get; private set; }

        /// <summary>
        /// Monotinicity of this polynomial (intervals in which this polynomial is increasing and decreasing)
        /// </summary>
        public (List<Interval> increasing, List<Interval> decreasing)? Monotinicity { get; private set; }

        /// <summary>
        /// Intervals in which this polynomial has only positive values
        /// </summary>
        public List<Interval>? PositiveValues { get; private set; }

        /// <summary>
        /// Intervals in which this polynomial has only negative values
        /// </summary>
        public List<Interval>? NegativeValues { get; private set; }

        /// <summary>
        /// Create polynomial from formula
        /// </summary>
        /// <param name="polynomial">Polynomial formula as string</param>
        public Polynomial(string polynomial) {

            polynomial = polynomial.Replace(" ", "");

            Coefficients = FindCoefficients(polynomial);
                  

        }

        /// <summary>
        /// Creates polynomial with all coefficients set to 0
        /// </summary>
        /// <param name="degree">Degree of polynomial</param>
        public Polynomial(int degree)
        {
            Coefficients = new double[degree+1];
        }

        /// <summary>
        /// Creates polynomial from coefficients array
        /// </summary>
        /// <param name="coefficients">Array of coefficients</param>
        public Polynomial(double[] coefficients)
        {
            Coefficients = coefficients;
        }

        /// <summary>
        /// Finds coefficients of this polynomial
        /// </summary>
        /// <param name="polynomial">String of polynomial formula</param>
        /// <returns>Array of coefficients</returns>
        private double[] FindCoefficients(string polynomial)
        {

            int degree = FindDegree(polynomial);

            double[] coefficients = new double[degree+1];

            string temp = "";

            for (int i = 0; i < polynomial.Length; i++)
            {
                char c = polynomial[i];

                if (c == 'x')
                {
                    if ((polynomial.Length - 1) - i >= 2 && polynomial[i + 1] == '^')
                    {
                        string temp2 = "";

                        for (i = i + 2; i < polynomial.Length; i++)
                        {
                            c = polynomial[i];

                            if (c == '+' || c == '-')
                                break;

                            temp2 += c;
                        }

                        coefficients[int.Parse(temp2)] += ParseCoefficient(temp);
                        temp = "" + c;

                    }
                    else
                    {
                        coefficients[1] += ParseCoefficient(temp);
                        temp = "";
                    }
                }
                else if (((polynomial.Length - 1) - i > 1 && (polynomial[i + 1] == '+' || polynomial[i + 1] == '-')))
                {
                    coefficients[0] += ParseCoefficient(temp);
                }
                else if (i == polynomial.Length - 1)
                {
                    temp += c;
                    coefficients[0] += ParseCoefficient(temp);
                }
                else
                {
                    temp += c;
                }

            }

            return coefficients;

        }

        /// <summary>
        /// Parses string coefficient to double coefficient
        /// </summary>
        /// <param name="coefficient">Coefficient as string</param>
        /// <returns>Coefficient as double</returns>
        private double ParseCoefficient(string coefficient)
        {
            if (coefficient == "" || coefficient == "+")
                return 1;
            else if (coefficient == "-")
                return -1;
            else
                return Double.Parse(coefficient);
        }

        /// <summary>
        /// Finds degree of this polynomial
        /// </summary>
        /// <param name="polynomial">String of polynomial formula</param>
        /// <returns>Degree</returns>
        private int FindDegree(string polynomial)
        {
            int degree = -1;

            for (int i = 0; i < polynomial.Length; i++)
            {
                char c = polynomial[i];

                if (c == 'x')
                {
                    if ((polynomial.Length - 1) - i >= 2 && polynomial[i + 1] == '^')
                    {
                        string temp = "";

                        for (i = i + 2; i < polynomial.Length; i++)
                        {
                            c = polynomial[i];

                            if (c == '+' || c == '-')
                                break;

                            temp += c;
                        }

                        int degree2 = int.Parse(temp);

                        if (degree2 > degree)
                            degree = degree2;

                    }
                    else
                    {
                        if (1 > degree)
                            degree = 1;
                    }
                }
            }

            return degree;
        }

        /// <summary>
        /// Gets value of W(x) for this polynomial
        /// </summary>
        /// <param name="x">x</param>
        /// <returns>Value of y</returns>
        public double Y(double x)
        {
            double y = 0;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                y += Coefficients[i] * Math.Pow(x, i);
            }

            return y;
        }

        /// <summary>
        /// Gets derivative of this polynomial
        /// </summary>
        /// <returns>Derivative</returns>
        private Polynomial GetDerivative()
        {
            Polynomial newPoly = new Polynomial(Degree - 1);

            for (int i = Coefficients.Length - 1; i > 0; i--)
            {
                newPoly.Coefficients[i-1] = Coefficients[i] * i;
            }

            return newPoly;
        }

        /// <summary>
        /// Gets Sturm sequence for this polynomial 
        /// </summary>
        /// <returns>Sturm sequence</returns>
        private List<Polynomial> GetSturmSequence()
        {
            List<Polynomial> sequence = new List<Polynomial>();

            sequence.Add(this);
            sequence.Add(GetDerivative());

            while(sequence.Last().Degree > 0)
            {
                var a = sequence[sequence.Count -2];
                var b = sequence[sequence.Count -1];

                sequence.Add(-(a % b));
            }


            return sequence;
        }

        /// <summary>
        /// Finds roots of this polynomial and assigns them to Roots property
        /// </summary>
        public void FindRoots()
        {
            Roots = new List<Root>();

            if (Degree < 1)
                return;

            if(Degree == 2)
            {
                var a = Coefficients[2];
                var b = Coefficients[1];
                var c = Coefficients[0];

                var delta = b * b - 4 * a * c;
                var deltaSqrt = Math.Sqrt(delta);


                if(delta > 0)
                {
                    var x1 = (-b - deltaSqrt) / (2 * a);
                    var x2 = (-b + deltaSqrt) / (2 * a);

                    AddRoot(x1);
                    AddRoot(x2);
                }
                else if(delta == 0)
                {
                    var x0 = -b / (2 * a);

                    AddRoot(x0, 2);
                }

                return;

            }

            if (Coefficients[0] == 0)
            {
                Roots.Add(new Root(0));

                double[] newCoefficients = { 0, 1 };

                var newPoly = this / new Polynomial(newCoefficients);

                newPoly.FindRoots();

                foreach (var root2 in newPoly.Roots!)
                {
                    AddRoot(root2.Value, root2.Multiplicity);
                }

                Roots = Roots.OrderBy(r => r.Value).ToList();

                return;
            }

            var areAllCoefficientsInteger = true;

            foreach (var Coefficient in Coefficients)
            {
                if(Coefficient != Math.Floor(Coefficient))
                {
                    areAllCoefficientsInteger = false;
                    break;
                }
                    
            }

            if (areAllCoefficientsInteger)
            {
                var ps = GetDivisors((int)Coefficients[0]);
                var qs = GetDivisors((int)Coefficients[Coefficients.Length-1]);

                foreach (double p in ps)
                {
                    foreach (double q in qs)
                    {
                        double root = p / q;

                        if(this.Y(root) == 0)
                        {
                            AddRoot(root);

                            double[] newCoefficients = {-root, 1};

                            var newPoly = this / new Polynomial(newCoefficients);

                            newPoly.FindRoots();

                            foreach (var root2 in newPoly.Roots!)
                            {
                                AddRoot(root2.Value, root2.Multiplicity);
                            }

                            Roots = Roots.OrderBy(r => r.Value).ToList();

                            return;

                        }

                        root = -(p / q);

                        if (this.Y(root) == 0)
                        {
                            AddRoot(root);

                            double[] newCoefficients = {-root, 1};

                            var newPoly = this / new Polynomial(newCoefficients);

                            newPoly.FindRoots();

                            foreach (var root2 in newPoly.Roots!)
                            {
                                AddRoot(root2.Value, root2.Multiplicity);
                            }

                            Roots = Roots.OrderBy(r => r.Value).ToList();

                            return;

                        }

                    }
                }
            }

            var derivative = GetDerivative();

            var sturmSequence = GetSturmSequence();

            var intervalsWithRoots = FindIntervalsWithRoots(new Interval(-100, 100), sturmSequence);

            foreach (var intervalsWithRoot in intervalsWithRoots)
            {
                var interval = intervalsWithRoot.interval;
                var multiplicity = intervalsWithRoot.multiplicity;

                double root = (double)((interval.A + interval.B) / 2)!;

                for (int i = 0; i < 10000; i++)
                {
                    root = NewtonRaphson(root, derivative);
                }


                AddRoot(root, multiplicity);
            }

            Roots = Roots.OrderBy(r => r.Value).ToList();

        }

        /// <summary>
        /// Adds new root or changes the multiplicity of existing one
        /// </summary>
        /// <param name="value">Value of root</param>
        /// <param name="multiplicity">Multiplicity of root</param>
        private void AddRoot(double value, int multiplicity = 1)
        {
            var root = Roots!.Find(r => r.Value == value);

            if (root != null)
                root.Multiplicity += multiplicity;
            else
                Roots.Add(new Root(value, multiplicity));
        }

        /// <summary>
        /// Finds x divisors
        /// </summary>
        /// <param name="x">Number to divide</param>
        /// <returns>List of x divisors</returns>
        private List<int> GetDivisors(int x)
        {
            x = Math.Abs(x); 

            if (x == 0)
            {
                return null!;
            }
            List<int> divisors = new List<int>();
            for (int i = 1; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    divisors.Add(i);
                    if (i != x / i)
                    {
                        divisors.Add(x / i);
                    }
                }
            }
            divisors.Sort();

            return divisors;
        }

        /// <summary>
        /// Finds approximate root
        /// </summary>
        /// <param name="x0">Approximate root</param>
        /// <param name="derivative">Derivative of this polynomial</param>
        /// <returns>Approximate root</returns>
        private double NewtonRaphson(double x0, Polynomial derivative) => x0 - this.Y(x0) / derivative.Y(x0);

        /// <summary>
        /// Finds intervals with one root
        /// </summary>
        /// <param name="interval">Interval in which function should look for intervals with one root</param>
        /// <param name="sturmSequence">Sturm sequence for this polynomial</param>
        /// <returns>Intervals with one root</returns>
        private List<(Interval interval, int multiplicity)> FindIntervalsWithRoots(Interval interval, List<Polynomial> sturmSequence)
        {
            List<(Interval interval, int multiplicity)> intervals = new List<(Interval interval, int multiplicity)>();

            var rootsCount = GetRootsCountInInterval(interval, sturmSequence);

            // 1 root
            if (Math.Abs((double)(interval.A - interval.B)!) < 0.01 
                || (Math.Abs((double)(interval.A - interval.B)!) < 2 && rootsCount == 1))
            {
                intervals.Add((interval, rootsCount));
            }
            // > 1 root
            else if(rootsCount > 1 || Math.Abs((double)(interval.A - interval.B)!) > 2)
            {
                double[] newInterval1 = new double[2];
                
                double c = (double)((interval.A + interval.B) / 2)!;

                foreach (var i in FindIntervalsWithRoots(new Interval(interval.A, c), sturmSequence))
                {
                    intervals.Add(i);
                }

                foreach (var i in FindIntervalsWithRoots(new Interval(c, interval.B), sturmSequence))
                {
                    intervals.Add(i);
                }
            }

            return intervals;

        }

        /// <summary>
        /// Gets count of roots in interval
        /// </summary>
        /// <param name="interval">Interval to chcek</param>
        /// <param name="sturmSequence">Sturm sequence for this polynomial</param>
        /// <returns>Count of roots in interval</returns>
        private int GetRootsCountInInterval(Interval interval, List<Polynomial> sturmSequence)
        {
            int countA = 0;

            List<double> yForA = new List<Double>(); 

            for (int i = 0; i < sturmSequence.Count; i++)
            {
                var value = sturmSequence[i].Y((double)interval.A!);

                if(value != 0)
                    yForA.Add(value);
            }

            for (int i = 0; i < yForA.Count -1; i++)
            {
                if (yForA[i] * yForA[i+1] < 0)
                    countA++;
            }

            int countB = 0;

            List<double> yForB = new List<double>();

            for (int i = 0; i < sturmSequence.Count; i++)
            {
                var value = sturmSequence[i].Y((double)interval.B!);

                if (value != 0)
                    yForB.Add(value);
            }

            for (int i = 0; i < yForB.Count - 1; i++)
            {
                if (yForB[i] * yForB[i+1] < 0)
                    countB++;
            }

            return Math.Abs(countA - countB);
        }

        /// <summary>
        /// Finds extreme values of this polynomial and assigns them to ExtremeValues property
        /// </summary>
        public void FindExtremeValues()
        {
            ExtremeValues = new List<Point>();

            var derivative = GetDerivative();

            derivative.FindRoots();

            foreach(var root in derivative.Roots!)
            {
                if(root.Multiplicity % 2 != 0)
                {
                    var newPoint = new Point(root.Value, this.Y(root.Value));
                    ExtremeValues.Add(newPoint);
                }
            }
        }

        /// <summary>
        /// Finds monotinicity of this polynomial's function
        /// </summary>
        public void FindMonotinicity()
        {
            if (Roots == null)
                FindRoots();

            if(ExtremeValues ==  null)
                FindExtremeValues();

            List<Interval> increasing = new List<Interval>();
            List<Interval> decreasing = new List<Interval>();

            // multiplicity = 0 for ExtremeValues
            List<(double x, int multiplicity)> points = new List<(double x, int multiplicity)>();

            foreach (var root in Roots!)
            {
                points.Add((root.Value, root.Multiplicity));
            }

            foreach (var extremeValue in ExtremeValues!)
            {
                points.Add((extremeValue.X, 0));
            }

            points = points.DistinctBy(p => p.x).OrderBy(points => points.x).Reverse().ToList();

            bool isIncreasing = Coefficients[Coefficients.Length - 1] > 0;

            double? b = null;

            foreach(var point in points)
            {
                if(point.multiplicity % 2 == 0)
                {
                    if (isIncreasing)
                        increasing.Add(new Interval(point.x, b, true));
                    else
                        decreasing.Add(new Interval(point.x, b, true));

                    b = point.x;
                    isIncreasing = !isIncreasing;
                }
            }

            if (isIncreasing)
                increasing.Add(new Interval(null, b, true));
            else
                decreasing.Add(new Interval(null, b, true));

            increasing.Reverse();
            decreasing.Reverse();

            Monotinicity = (increasing, decreasing);

        }

        /// <summary>
        /// Finds for which x, y is positive and  for which x, y is negative
        /// </summary>
        public void FindPositiveAndNegativeValues()
        {
            List<Interval> positiveValues = new List<Interval>();
            List<Interval> negativeValues = new List<Interval>();

            if (Roots == null)
                FindRoots();

            bool isPositive = Coefficients[Coefficients.Length -1 ] > 0;

            double? b = null;

            for (int i = Roots!.Count - 1; i >= 0; i--)
            {
                var root = Roots[i];

                if (isPositive)
                    positiveValues.Add(new Interval(root.Value, b));
                else
                    negativeValues.Add(new Interval(root.Value, b));

                b = root.Value;

                if (root.Multiplicity % 2 != 0)
                    isPositive = !isPositive;
                
            }

            if (isPositive)
                positiveValues.Add(new Interval(null, b));
            else
                negativeValues.Add(new Interval(null, b));

            positiveValues.Reverse();
            negativeValues.Reverse();

            PositiveValues = positiveValues;
            NegativeValues = negativeValues;
        }

        /// <summary>
        /// Finds this set of values of this polynomial
        /// </summary>
        public void FindValuesSet()
        {

            if (PositiveValues == null || NegativeValues == null)
                FindPositiveAndNegativeValues();

            double? a = null;
            double? b = null;

            //looking for a
            if (!((Monotinicity!.Value.increasing.Count > 0 && Monotinicity!.Value.increasing.First().A == null) || (Monotinicity!.Value.decreasing.Count > 0 && Monotinicity!.Value.decreasing.Last().B == null)))
            {
                var minValue = ExtremeValues!.MinBy(e => e.Y);

                a = minValue == null ? null : minValue.Y;

                if (Roots!.Count > 0 && (a == null || a > 0)) 
                    a = 0;

            }

            //looking for b
            if (!((Monotinicity!.Value.decreasing.Count > 0 && Monotinicity!.Value.decreasing.First().A == null) || (Monotinicity!.Value.increasing.Count > 0 && Monotinicity!.Value.increasing.Last().B == null)))  
            {
                var minValue = ExtremeValues!.MaxBy(e => e.Y);

                b = minValue == null ? null : minValue.Y;

                if (Roots!.Count > 0 && (b == null || a < 0))
                    b = 0;
            }

            ValuesSet = new Interval(a, b, true);
        }

        /// <summary>
        /// Gets points for graph
        /// </summary>
        /// <returns>Array of points</returns>
        public Point[] GetPointsForGraph()
        {
            if (Roots == null)
                FindRoots();

            if (ExtremeValues == null)
                FindExtremeValues();

            List<Point> points = new List<Point>();

            foreach (var root in Roots!)
            {
                points.Add(new Point(root.Value, 0));
            }

            foreach (var extremeValue in ExtremeValues!) 
            {
                points.Add(extremeValue);
            }

            double left = -2;
            double right = 2;

            if (Roots != null && ExtremeValues != null && Roots.Count > 0 && ExtremeValues.Count > 0)
            {
                left = Roots[0].Value < ExtremeValues![0].X ? Roots[0].Value - 2 : ExtremeValues[0].X - 2;

                right = Roots.Last().Value > ExtremeValues!.Last().X ? Roots.Last().Value + 2 : ExtremeValues.Last().X + 2;
            }
            else if (Roots != null && Roots.Count > 0)
            {
                left = Roots[0].Value - 2;

                right = Roots.Last().Value + 2;
            }
            else if (ExtremeValues != null && ExtremeValues.Count > 0)
            {
                left = ExtremeValues[0].X - 2;

                right = ExtremeValues.Last().X + 2;
            }

            var edgeValue = Math.Abs(left) > Math.Abs(right) ? Math.Abs(left) : Math.Abs(right);

            edgeValue = Math.Ceiling(edgeValue);

            points.Add(new Point(-edgeValue, this.Y(-edgeValue)));
            points.Add(new Point(edgeValue, this.Y(edgeValue)));

            return points.DistinctBy(p => p.X).OrderBy(p => p.X).ToArray();
        }

        /// <summary>
        /// Changes sign of polynomial
        /// </summary>
        /// <param name="a">Polynomial</param>
        /// <returns>New polynomial with changed sign</returns>
        public static Polynomial operator -(Polynomial a)
        {
            Polynomial newPoly =  new Polynomial(a.Coefficients);

            for (int i = 0; i < newPoly.Coefficients.Length; i++)
            {
                newPoly.Coefficients[i] *= -1; 
            }

            return newPoly;
        }

        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>New polynomial resulting from adding those two polynomials</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int degree = a.Degree > b.Degree ? a.Degree : b.Degree;

            Polynomial newPoly = new Polynomial(degree);

            for (int i = 0; i < a.Coefficients.Length; i++)
            {
                newPoly.Coefficients[i] += a.Coefficients[i];
            }

            for (int i = 0; i < b.Coefficients.Length; i++)
            {
                newPoly.Coefficients[i] += b.Coefficients[i];
            }

            return newPoly;
        }

        /// <summary>
        /// Subtract two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>New polynomial resulting from subtracting those two polynomials</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            int degree = a.Degree > b.Degree ? a.Degree : b.Degree;

            double[] newCoefficients = new double[degree+1];

            for (int i = 0; i < a.Coefficients.Length; i++)
            {
                newCoefficients[i] += a.Coefficients[i];
            }

            for (int i = 0; i < b.Coefficients.Length; i++)
            {
                newCoefficients[i] -= b.Coefficients[i];
            }

            int newDegree = -1;

            for (int i = newCoefficients.Length - 1; i >= 0; i--)
            {
                if (newCoefficients[i] != 0)
                {
                    newDegree = i;
                    break;
                }
            }

            Polynomial newPoly = new Polynomial(newDegree);

            for (int i = 0; i < newPoly.Coefficients.Length; i++)
            {
                newPoly.Coefficients[i] = newCoefficients[i];
            }

            return newPoly;
        }

        /// <summary>
        /// Multiply two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>New polynomial resulting from multiplying those two polynomials</returns>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            int deegre = a.Degree + b.Degree;

            Polynomial newPoly = new Polynomial(deegre);

            for (int i = 0; i < a.Coefficients.Length; i++)
            {
                for (int j = 0; j < b.Coefficients.Length; j++)
                {
                    newPoly.Coefficients[i + j] += (a.Coefficients[i] * b.Coefficients[j]);
                }
            }

            return newPoly;
        }

        /// <summary>
        /// Devide two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>New polynomial resulting from devideing those two polynomials</returns>
        public static Polynomial operator / (Polynomial a, Polynomial b)
        {
            Polynomial rest;

            return Devide(a, b, out rest);
        }

        /// <summary>
        /// Modulo divide two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <returns>New polynomial resulting from modulo devideing those two polynomials</returns>
        public static Polynomial operator %(Polynomial a, Polynomial b)
        {
            Polynomial rest;

            Devide(a, b, out rest);

            return rest;
        }

        /// <summary>
        /// Divides two polynomials
        /// </summary>
        /// <param name="a">First polynomial</param>
        /// <param name="b">Second polynomial</param>
        /// <param name="rest">Rest from division</param>
        /// <returns>A polynomial resulting from division</returns>
        public static Polynomial Devide(Polynomial a, Polynomial b, out Polynomial rest)
        {
            Polynomial a1 = new Polynomial(a.Coefficients);

            int deegre = a.Degree - b.Degree;

            Polynomial newPoly = new Polynomial(deegre);

            int i = a1.Degree;

            do
            {
                int tempDeegree = i - b.Degree;

                if (a1.Degree < b.Degree)
                    break;

                Polynomial tempPoly = new Polynomial(tempDeegree);

                tempPoly.Coefficients[tempDeegree] = a1.Coefficients[i] / b.Coefficients[b.Degree];

                newPoly.Coefficients[tempDeegree] = tempPoly.Coefficients[tempDeegree];

                a1 = a1 - (tempPoly * b);

                i = a1.Degree;

            } while (i > 0);

            rest = a1;

            return newPoly;
        }

        /// <summary>
        /// Gets polynomial formula
        /// </summary>
        /// <returns>Polynomial formula sa string</returns>
        public override string ToString()
        {
            string st = "";

            for (int i = Coefficients.Length - 1; i >= 2; i--)
            {
                double coefficient = Coefficients[i];
                if (coefficient != 0)
                { 
                    if (coefficient >= 0)
                        st += "+";

                    st += coefficient + "x^" + i;
                }
            }

            if(Coefficients.Length >= 2 && Coefficients[1] != 0)
            {
                double coefficient = Coefficients[1];

                if (coefficient >= 0)
                    st += "+";

                st += coefficient + "x";
            }

            if (Coefficients.Length >= 1 && Coefficients[0] != 0)
            {
                double coefficient = Coefficients[0];

                if (coefficient >= 0)
                    st += "+";

                st += coefficient;
            }

            if (st.Length > 1 && st[0] == '+') 
                st = st.Substring(1);

            return st;

        }

    }
}
