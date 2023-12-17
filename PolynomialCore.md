<a name='assembly'></a>
# PolynomialCore

## Contents

- [Interval](#T-PolynomialCore-Interval 'PolynomialCore.Interval')
  - [#ctor(a,b,autoClose)](#M-PolynomialCore-Interval-#ctor-System-Nullable{System-Double},System-Nullable{System-Double},System-Boolean- 'PolynomialCore.Interval.#ctor(System.Nullable{System.Double},System.Nullable{System.Double},System.Boolean)')
  - [#ctor(a,isAClosed,b,isBClosed)](#M-PolynomialCore-Interval-#ctor-System-Nullable{System-Double},System-Boolean,System-Nullable{System-Double},System-Boolean- 'PolynomialCore.Interval.#ctor(System.Nullable{System.Double},System.Boolean,System.Nullable{System.Double},System.Boolean)')
  - [A](#P-PolynomialCore-Interval-A 'PolynomialCore.Interval.A')
  - [B](#P-PolynomialCore-Interval-B 'PolynomialCore.Interval.B')
  - [IsAClosed](#P-PolynomialCore-Interval-IsAClosed 'PolynomialCore.Interval.IsAClosed')
  - [IsBClosed](#P-PolynomialCore-Interval-IsBClosed 'PolynomialCore.Interval.IsBClosed')
  - [Contains(x)](#M-PolynomialCore-Interval-Contains-System-Double- 'PolynomialCore.Interval.Contains(System.Double)')
  - [ToString()](#M-PolynomialCore-Interval-ToString 'PolynomialCore.Interval.ToString')
- [Point](#T-PolynomialCore-Point 'PolynomialCore.Point')
  - [#ctor(x,y)](#M-PolynomialCore-Point-#ctor-System-Double,System-Double- 'PolynomialCore.Point.#ctor(System.Double,System.Double)')
  - [X](#P-PolynomialCore-Point-X 'PolynomialCore.Point.X')
  - [Y](#P-PolynomialCore-Point-Y 'PolynomialCore.Point.Y')
- [Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial')
  - [#ctor(polynomial)](#M-PolynomialCore-Polynomial-#ctor-System-String- 'PolynomialCore.Polynomial.#ctor(System.String)')
  - [#ctor(degree)](#M-PolynomialCore-Polynomial-#ctor-System-Int32- 'PolynomialCore.Polynomial.#ctor(System.Int32)')
  - [#ctor(coefficients)](#M-PolynomialCore-Polynomial-#ctor-System-Double[]- 'PolynomialCore.Polynomial.#ctor(System.Double[])')
  - [Coefficients](#P-PolynomialCore-Polynomial-Coefficients 'PolynomialCore.Polynomial.Coefficients')
  - [Degree](#P-PolynomialCore-Polynomial-Degree 'PolynomialCore.Polynomial.Degree')
  - [ExtremeValues](#P-PolynomialCore-Polynomial-ExtremeValues 'PolynomialCore.Polynomial.ExtremeValues')
  - [Monotinicity](#P-PolynomialCore-Polynomial-Monotinicity 'PolynomialCore.Polynomial.Monotinicity')
  - [NegativeValues](#P-PolynomialCore-Polynomial-NegativeValues 'PolynomialCore.Polynomial.NegativeValues')
  - [PositiveValues](#P-PolynomialCore-Polynomial-PositiveValues 'PolynomialCore.Polynomial.PositiveValues')
  - [Roots](#P-PolynomialCore-Polynomial-Roots 'PolynomialCore.Polynomial.Roots')
  - [ValuesSet](#P-PolynomialCore-Polynomial-ValuesSet 'PolynomialCore.Polynomial.ValuesSet')
  - [AddRoot(value,multiplicity)](#M-PolynomialCore-Polynomial-AddRoot-System-Double,System-Int32- 'PolynomialCore.Polynomial.AddRoot(System.Double,System.Int32)')
  - [Devide(a,b,rest)](#M-PolynomialCore-Polynomial-Devide-PolynomialCore-Polynomial,PolynomialCore-Polynomial,PolynomialCore-Polynomial@- 'PolynomialCore.Polynomial.Devide(PolynomialCore.Polynomial,PolynomialCore.Polynomial,PolynomialCore.Polynomial@)')
  - [FindCoefficients(polynomial)](#M-PolynomialCore-Polynomial-FindCoefficients-System-String- 'PolynomialCore.Polynomial.FindCoefficients(System.String)')
  - [FindDegree(polynomial)](#M-PolynomialCore-Polynomial-FindDegree-System-String- 'PolynomialCore.Polynomial.FindDegree(System.String)')
  - [FindExtremeValues()](#M-PolynomialCore-Polynomial-FindExtremeValues 'PolynomialCore.Polynomial.FindExtremeValues')
  - [FindIntervalsWithRoots(interval,sturmSequence)](#M-PolynomialCore-Polynomial-FindIntervalsWithRoots-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}- 'PolynomialCore.Polynomial.FindIntervalsWithRoots(PolynomialCore.Interval,System.Collections.Generic.List{PolynomialCore.Polynomial})')
  - [FindMonotinicity()](#M-PolynomialCore-Polynomial-FindMonotinicity 'PolynomialCore.Polynomial.FindMonotinicity')
  - [FindPositiveAndNegativeValues()](#M-PolynomialCore-Polynomial-FindPositiveAndNegativeValues 'PolynomialCore.Polynomial.FindPositiveAndNegativeValues')
  - [FindRoots()](#M-PolynomialCore-Polynomial-FindRoots 'PolynomialCore.Polynomial.FindRoots')
  - [FindValuesSet()](#M-PolynomialCore-Polynomial-FindValuesSet 'PolynomialCore.Polynomial.FindValuesSet')
  - [GetDerivative()](#M-PolynomialCore-Polynomial-GetDerivative 'PolynomialCore.Polynomial.GetDerivative')
  - [GetDivisors(x)](#M-PolynomialCore-Polynomial-GetDivisors-System-Int32- 'PolynomialCore.Polynomial.GetDivisors(System.Int32)')
  - [GetPointsForGraph()](#M-PolynomialCore-Polynomial-GetPointsForGraph 'PolynomialCore.Polynomial.GetPointsForGraph')
  - [GetRootsCountInInterval(interval,sturmSequence)](#M-PolynomialCore-Polynomial-GetRootsCountInInterval-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}- 'PolynomialCore.Polynomial.GetRootsCountInInterval(PolynomialCore.Interval,System.Collections.Generic.List{PolynomialCore.Polynomial})')
  - [GetSturmSequence()](#M-PolynomialCore-Polynomial-GetSturmSequence 'PolynomialCore.Polynomial.GetSturmSequence')
  - [NewtonRaphson(x0,derivative)](#M-PolynomialCore-Polynomial-NewtonRaphson-System-Double,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.NewtonRaphson(System.Double,PolynomialCore.Polynomial)')
  - [ParseCoefficient(coefficient)](#M-PolynomialCore-Polynomial-ParseCoefficient-System-String- 'PolynomialCore.Polynomial.ParseCoefficient(System.String)')
  - [ToString()](#M-PolynomialCore-Polynomial-ToString 'PolynomialCore.Polynomial.ToString')
  - [Y(x)](#M-PolynomialCore-Polynomial-Y-System-Double- 'PolynomialCore.Polynomial.Y(System.Double)')
  - [op_Addition(a,b)](#M-PolynomialCore-Polynomial-op_Addition-PolynomialCore-Polynomial,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.op_Addition(PolynomialCore.Polynomial,PolynomialCore.Polynomial)')
  - [op_Division(a,b)](#M-PolynomialCore-Polynomial-op_Division-PolynomialCore-Polynomial,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.op_Division(PolynomialCore.Polynomial,PolynomialCore.Polynomial)')
  - [op_Modulus(a,b)](#M-PolynomialCore-Polynomial-op_Modulus-PolynomialCore-Polynomial,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.op_Modulus(PolynomialCore.Polynomial,PolynomialCore.Polynomial)')
  - [op_Multiply(a,b)](#M-PolynomialCore-Polynomial-op_Multiply-PolynomialCore-Polynomial,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.op_Multiply(PolynomialCore.Polynomial,PolynomialCore.Polynomial)')
  - [op_Subtraction(a,b)](#M-PolynomialCore-Polynomial-op_Subtraction-PolynomialCore-Polynomial,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.op_Subtraction(PolynomialCore.Polynomial,PolynomialCore.Polynomial)')
  - [op_UnaryNegation(a)](#M-PolynomialCore-Polynomial-op_UnaryNegation-PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.op_UnaryNegation(PolynomialCore.Polynomial)')
- [Root](#T-PolynomialCore-Root 'PolynomialCore.Root')
  - [#ctor(value,multiplicity)](#M-PolynomialCore-Root-#ctor-System-Double,System-Int32- 'PolynomialCore.Root.#ctor(System.Double,System.Int32)')
  - [Multiplicity](#P-PolynomialCore-Root-Multiplicity 'PolynomialCore.Root.Multiplicity')
  - [Value](#P-PolynomialCore-Root-Value 'PolynomialCore.Root.Value')

<a name='T-PolynomialCore-Interval'></a>
## Interval `type`

##### Namespace

PolynomialCore

##### Summary

Represents an interval (A; B)
If A or B is null they are respectively -∞ and +∞

<a name='M-PolynomialCore-Interval-#ctor-System-Nullable{System-Double},System-Nullable{System-Double},System-Boolean-'></a>
### #ctor(a,b,autoClose) `constructor`

##### Summary

Generates new interval

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Left value |
| b | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Right value |
| autoClose | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Should it be automaticly closed |

<a name='M-PolynomialCore-Interval-#ctor-System-Nullable{System-Double},System-Boolean,System-Nullable{System-Double},System-Boolean-'></a>
### #ctor(a,isAClosed,b,isBClosed) `constructor`

##### Summary

Generates new interval

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Left value |
| isAClosed | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Is it closed on the left side |
| b | [System.Nullable{System.Double}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Double}') | Right value |
| isBClosed | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Is it closed on the right side |

<a name='P-PolynomialCore-Interval-A'></a>
### A `property`

##### Summary

Left value of this interval

<a name='P-PolynomialCore-Interval-B'></a>
### B `property`

##### Summary

Right value of this interval

<a name='P-PolynomialCore-Interval-IsAClosed'></a>
### IsAClosed `property`

##### Summary

Is this interval closed on the left side

<a name='P-PolynomialCore-Interval-IsBClosed'></a>
### IsBClosed `property`

##### Summary

Is this interval closed on the right side

<a name='M-PolynomialCore-Interval-Contains-System-Double-'></a>
### Contains(x) `method`

##### Summary

Gets if this interval contains x

##### Returns

True/false

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | X value |

<a name='M-PolynomialCore-Interval-ToString'></a>
### ToString() `method`

##### Summary

Gets this interval as a string

##### Returns

This interval as a string

##### Parameters

This method has no parameters.

<a name='T-PolynomialCore-Point'></a>
## Point `type`

##### Namespace

PolynomialCore

##### Summary

Represents a point in cartesian coordinate system

<a name='M-PolynomialCore-Point-#ctor-System-Double,System-Double-'></a>
### #ctor(x,y) `constructor`

##### Summary

Generates new point

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | X value |
| y | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Y value |

<a name='P-PolynomialCore-Point-X'></a>
### X `property`

##### Summary

X value of this point

<a name='P-PolynomialCore-Point-Y'></a>
### Y `property`

##### Summary

Y value of this point

<a name='T-PolynomialCore-Polynomial'></a>
## Polynomial `type`

##### Namespace

PolynomialCore

##### Summary

Class representing a polynomial

<a name='M-PolynomialCore-Polynomial-#ctor-System-String-'></a>
### #ctor(polynomial) `constructor`

##### Summary

Create polynomial from formula

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polynomial | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Polynomial formula as string |

<a name='M-PolynomialCore-Polynomial-#ctor-System-Int32-'></a>
### #ctor(degree) `constructor`

##### Summary

Creates polynomial with all coefficients set to 0

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| degree | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Degree of polynomial |

<a name='M-PolynomialCore-Polynomial-#ctor-System-Double[]-'></a>
### #ctor(coefficients) `constructor`

##### Summary

Creates polynomial from coefficients array

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coefficients | [System.Double[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double[] 'System.Double[]') | Array of coefficients |

<a name='P-PolynomialCore-Polynomial-Coefficients'></a>
### Coefficients `property`

##### Summary

Coefficients of this polynomial

<a name='P-PolynomialCore-Polynomial-Degree'></a>
### Degree `property`

##### Summary

Degree of this polynomial

<a name='P-PolynomialCore-Polynomial-ExtremeValues'></a>
### ExtremeValues `property`

##### Summary

Extreme values of this polynimial

<a name='P-PolynomialCore-Polynomial-Monotinicity'></a>
### Monotinicity `property`

##### Summary

Monotinicity of this polynomial (intervals in which this polynomial is increasing and decreasing)

<a name='P-PolynomialCore-Polynomial-NegativeValues'></a>
### NegativeValues `property`

##### Summary

Intervals in which this polynomial has only negative values

<a name='P-PolynomialCore-Polynomial-PositiveValues'></a>
### PositiveValues `property`

##### Summary

Intervals in which this polynomial has only positive values

<a name='P-PolynomialCore-Polynomial-Roots'></a>
### Roots `property`

##### Summary

Roots Of this polynomial

<a name='P-PolynomialCore-Polynomial-ValuesSet'></a>
### ValuesSet `property`

##### Summary

ValuesSet of this polynoamil

<a name='M-PolynomialCore-Polynomial-AddRoot-System-Double,System-Int32-'></a>
### AddRoot(value,multiplicity) `method`

##### Summary

Adds new root or changes the multiplicity of existing one

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Value of root |
| multiplicity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Multiplicity of root |

<a name='M-PolynomialCore-Polynomial-Devide-PolynomialCore-Polynomial,PolynomialCore-Polynomial,PolynomialCore-Polynomial@-'></a>
### Devide(a,b,rest) `method`

##### Summary

Divides two polynomials

##### Returns

A polynomial resulting from division

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | First polynomial |
| b | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Second polynomial |
| rest | [PolynomialCore.Polynomial@](#T-PolynomialCore-Polynomial@ 'PolynomialCore.Polynomial@') | Rest from division |

<a name='M-PolynomialCore-Polynomial-FindCoefficients-System-String-'></a>
### FindCoefficients(polynomial) `method`

##### Summary

Finds coefficients of this polynomial

##### Returns

Array of coefficients

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polynomial | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String of polynomial formula |

<a name='M-PolynomialCore-Polynomial-FindDegree-System-String-'></a>
### FindDegree(polynomial) `method`

##### Summary

Finds degree of this polynomial

##### Returns

Degree

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polynomial | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String of polynomial formula |

<a name='M-PolynomialCore-Polynomial-FindExtremeValues'></a>
### FindExtremeValues() `method`

##### Summary

Finds extreme values of this polynomial and assigns them to ExtremeValues property

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-FindIntervalsWithRoots-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}-'></a>
### FindIntervalsWithRoots(interval,sturmSequence) `method`

##### Summary

Finds intervals with one root

##### Returns

Intervals with one root

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [PolynomialCore.Interval](#T-PolynomialCore-Interval 'PolynomialCore.Interval') | Interval in which function should look for intervals with one root |
| sturmSequence | [System.Collections.Generic.List{PolynomialCore.Polynomial}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{PolynomialCore.Polynomial}') | Sturm sequence for this polynomial |

<a name='M-PolynomialCore-Polynomial-FindMonotinicity'></a>
### FindMonotinicity() `method`

##### Summary

Finds monotinicity of this polynomial's function

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-FindPositiveAndNegativeValues'></a>
### FindPositiveAndNegativeValues() `method`

##### Summary

Finds for which x, y is positive and  for which x, y is negative

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-FindRoots'></a>
### FindRoots() `method`

##### Summary

Finds roots of this polynomial and assigns them to Roots property

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-FindValuesSet'></a>
### FindValuesSet() `method`

##### Summary

Finds this set of values of this polynomial

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-GetDerivative'></a>
### GetDerivative() `method`

##### Summary

Gets derivative of this polynomial

##### Returns

Derivative

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-GetDivisors-System-Int32-'></a>
### GetDivisors(x) `method`

##### Summary

Finds x divisors

##### Returns

List of x divisors

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number to divide |

<a name='M-PolynomialCore-Polynomial-GetPointsForGraph'></a>
### GetPointsForGraph() `method`

##### Summary

Gets points for graph

##### Returns

Array of points

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-GetRootsCountInInterval-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}-'></a>
### GetRootsCountInInterval(interval,sturmSequence) `method`

##### Summary

Gets count of roots in interval

##### Returns

Count of roots in interval

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [PolynomialCore.Interval](#T-PolynomialCore-Interval 'PolynomialCore.Interval') | Interval to chcek |
| sturmSequence | [System.Collections.Generic.List{PolynomialCore.Polynomial}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{PolynomialCore.Polynomial}') | Sturm sequence for this polynomial |

<a name='M-PolynomialCore-Polynomial-GetSturmSequence'></a>
### GetSturmSequence() `method`

##### Summary

Gets Sturm sequence for this polynomial

##### Returns

Sturm sequence

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-NewtonRaphson-System-Double,PolynomialCore-Polynomial-'></a>
### NewtonRaphson(x0,derivative) `method`

##### Summary

Finds approximate root

##### Returns

Approximate root

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x0 | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Approximate root |
| derivative | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Derivative of this polynomial |

<a name='M-PolynomialCore-Polynomial-ParseCoefficient-System-String-'></a>
### ParseCoefficient(coefficient) `method`

##### Summary

Parses string coefficient to double coefficient

##### Returns

Coefficient as double

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coefficient | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Coefficient as string |

<a name='M-PolynomialCore-Polynomial-ToString'></a>
### ToString() `method`

##### Summary

Gets polynomial formula

##### Returns

Polynomial formula sa string

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-Y-System-Double-'></a>
### Y(x) `method`

##### Summary

Gets value of W(x) for this polynomial

##### Returns

Value of y

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | x |

<a name='M-PolynomialCore-Polynomial-op_Addition-PolynomialCore-Polynomial,PolynomialCore-Polynomial-'></a>
### op_Addition(a,b) `method`

##### Summary

Adds two polynomials

##### Returns

New polynomial resulting from adding those two polynomials

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | First polynomial |
| b | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Second polynomial |

<a name='M-PolynomialCore-Polynomial-op_Division-PolynomialCore-Polynomial,PolynomialCore-Polynomial-'></a>
### op_Division(a,b) `method`

##### Summary

Devide two polynomials

##### Returns

New polynomial resulting from devideing those two polynomials

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | First polynomial |
| b | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Second polynomial |

<a name='M-PolynomialCore-Polynomial-op_Modulus-PolynomialCore-Polynomial,PolynomialCore-Polynomial-'></a>
### op_Modulus(a,b) `method`

##### Summary

Modulo divide two polynomials

##### Returns

New polynomial resulting from modulo devideing those two polynomials

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | First polynomial |
| b | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Second polynomial |

<a name='M-PolynomialCore-Polynomial-op_Multiply-PolynomialCore-Polynomial,PolynomialCore-Polynomial-'></a>
### op_Multiply(a,b) `method`

##### Summary

Multiply two polynomials

##### Returns

New polynomial resulting from multiplying those two polynomials

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | First polynomial |
| b | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Second polynomial |

<a name='M-PolynomialCore-Polynomial-op_Subtraction-PolynomialCore-Polynomial,PolynomialCore-Polynomial-'></a>
### op_Subtraction(a,b) `method`

##### Summary

Subtract two polynomials

##### Returns

New polynomial resulting from subtracting those two polynomials

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | First polynomial |
| b | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Second polynomial |

<a name='M-PolynomialCore-Polynomial-op_UnaryNegation-PolynomialCore-Polynomial-'></a>
### op_UnaryNegation(a) `method`

##### Summary

Changes sign of polynomial

##### Returns

New polynomial with changed sign

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Polynomial |

<a name='T-PolynomialCore-Root'></a>
## Root `type`

##### Namespace

PolynomialCore

##### Summary

Represents a polynomial root

<a name='M-PolynomialCore-Root-#ctor-System-Double,System-Int32-'></a>
### #ctor(value,multiplicity) `constructor`

##### Summary

Creates new root

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | X value |
| multiplicity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Multiplicity |

<a name='P-PolynomialCore-Root-Multiplicity'></a>
### Multiplicity `property`

##### Summary

Multiplicity of this root

<a name='P-PolynomialCore-Root-Value'></a>
### Value `property`

##### Summary

X value of this root
