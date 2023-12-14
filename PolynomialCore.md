<a name='assembly'></a>
# PolynomialCore

## Contents

- [Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial')
  - [addRoot(value,multiplicity)](#M-PolynomialCore-Polynomial-addRoot-System-Double,System-Int32- 'PolynomialCore.Polynomial.addRoot(System.Double,System.Int32)')
  - [devide(a,b,rest)](#M-PolynomialCore-Polynomial-devide-PolynomialCore-Polynomial,PolynomialCore-Polynomial,PolynomialCore-Polynomial@- 'PolynomialCore.Polynomial.devide(PolynomialCore.Polynomial,PolynomialCore.Polynomial,PolynomialCore.Polynomial@)')
  - [findCoefficients(polynomial)](#M-PolynomialCore-Polynomial-findCoefficients-System-String- 'PolynomialCore.Polynomial.findCoefficients(System.String)')
  - [findDegree(polynomial)](#M-PolynomialCore-Polynomial-findDegree-System-String- 'PolynomialCore.Polynomial.findDegree(System.String)')
  - [findExtremeValues()](#M-PolynomialCore-Polynomial-findExtremeValues 'PolynomialCore.Polynomial.findExtremeValues')
  - [findIntervalsWithRoots(interval,sturmSequence)](#M-PolynomialCore-Polynomial-findIntervalsWithRoots-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}- 'PolynomialCore.Polynomial.findIntervalsWithRoots(PolynomialCore.Interval,System.Collections.Generic.List{PolynomialCore.Polynomial})')
  - [findMonotinicity()](#M-PolynomialCore-Polynomial-findMonotinicity 'PolynomialCore.Polynomial.findMonotinicity')
  - [findPositiveAndNegativeValuse()](#M-PolynomialCore-Polynomial-findPositiveAndNegativeValuse 'PolynomialCore.Polynomial.findPositiveAndNegativeValuse')
  - [findRoots()](#M-PolynomialCore-Polynomial-findRoots 'PolynomialCore.Polynomial.findRoots')
  - [findValuesSet()](#M-PolynomialCore-Polynomial-findValuesSet 'PolynomialCore.Polynomial.findValuesSet')
  - [getDerivative()](#M-PolynomialCore-Polynomial-getDerivative 'PolynomialCore.Polynomial.getDerivative')
  - [getDivisors(x)](#M-PolynomialCore-Polynomial-getDivisors-System-Int32- 'PolynomialCore.Polynomial.getDivisors(System.Int32)')
  - [getPointsForGraph()](#M-PolynomialCore-Polynomial-getPointsForGraph 'PolynomialCore.Polynomial.getPointsForGraph')
  - [getRootsCountInInterval(interval,sturmSequence)](#M-PolynomialCore-Polynomial-getRootsCountInInterval-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}- 'PolynomialCore.Polynomial.getRootsCountInInterval(PolynomialCore.Interval,System.Collections.Generic.List{PolynomialCore.Polynomial})')
  - [getSturmSequence()](#M-PolynomialCore-Polynomial-getSturmSequence 'PolynomialCore.Polynomial.getSturmSequence')
  - [newtonRaphson(x0,derivative)](#M-PolynomialCore-Polynomial-newtonRaphson-System-Double,PolynomialCore-Polynomial- 'PolynomialCore.Polynomial.newtonRaphson(System.Double,PolynomialCore.Polynomial)')
  - [parseCoefficient(coefficient)](#M-PolynomialCore-Polynomial-parseCoefficient-System-String- 'PolynomialCore.Polynomial.parseCoefficient(System.String)')
  - [y(x)](#M-PolynomialCore-Polynomial-y-System-Double- 'PolynomialCore.Polynomial.y(System.Double)')

<a name='T-PolynomialCore-Polynomial'></a>
## Polynomial `type`

##### Namespace

PolynomialCore

<a name='M-PolynomialCore-Polynomial-addRoot-System-Double,System-Int32-'></a>
### addRoot(value,multiplicity) `method`

##### Summary

Adds new root or changes the multiplicity of existing one

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Value of root |
| multiplicity | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Multiplicity of root |

<a name='M-PolynomialCore-Polynomial-devide-PolynomialCore-Polynomial,PolynomialCore-Polynomial,PolynomialCore-Polynomial@-'></a>
### devide(a,b,rest) `method`

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

<a name='M-PolynomialCore-Polynomial-findCoefficients-System-String-'></a>
### findCoefficients(polynomial) `method`

##### Summary

Finds coefficients of this polynomial

##### Returns

Array of coefficients

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polynomial | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String of polynomial formula |

<a name='M-PolynomialCore-Polynomial-findDegree-System-String-'></a>
### findDegree(polynomial) `method`

##### Summary

Finds degree of this polynomial

##### Returns

Degree

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| polynomial | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | String of polynomial formula |

<a name='M-PolynomialCore-Polynomial-findExtremeValues'></a>
### findExtremeValues() `method`

##### Summary

Finds extreme values of this polynomial and assigns them to ExtremeValues property

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-findIntervalsWithRoots-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}-'></a>
### findIntervalsWithRoots(interval,sturmSequence) `method`

##### Summary

Finds intervals with one root

##### Returns

Intervals with one root

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [PolynomialCore.Interval](#T-PolynomialCore-Interval 'PolynomialCore.Interval') | Interval in which function should look for intervals with one root |
| sturmSequence | [System.Collections.Generic.List{PolynomialCore.Polynomial}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{PolynomialCore.Polynomial}') | Sturm sequence for this polynomial |

<a name='M-PolynomialCore-Polynomial-findMonotinicity'></a>
### findMonotinicity() `method`

##### Summary

Finds monotinicity of this polynomial's function

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-findPositiveAndNegativeValuse'></a>
### findPositiveAndNegativeValuse() `method`

##### Summary

Finds for which x, y is positive and  for which x, y is negative

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-findRoots'></a>
### findRoots() `method`

##### Summary

Finds roots of this polynomial and assigns them to Roots property

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-findValuesSet'></a>
### findValuesSet() `method`

##### Summary

Finds this set of values of this polynomial

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-getDerivative'></a>
### getDerivative() `method`

##### Summary

Gets derivative of this polynomial

##### Returns

Derivative

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-getDivisors-System-Int32-'></a>
### getDivisors(x) `method`

##### Summary

Finds x divisors

##### Returns

List of x divisors

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number to divide |

<a name='M-PolynomialCore-Polynomial-getPointsForGraph'></a>
### getPointsForGraph() `method`

##### Summary

Gets points for graph

##### Returns

Array of points

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-getRootsCountInInterval-PolynomialCore-Interval,System-Collections-Generic-List{PolynomialCore-Polynomial}-'></a>
### getRootsCountInInterval(interval,sturmSequence) `method`

##### Summary

Gets count of roots in interval

##### Returns

Count of roots in interval

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| interval | [PolynomialCore.Interval](#T-PolynomialCore-Interval 'PolynomialCore.Interval') | Interval to chcek |
| sturmSequence | [System.Collections.Generic.List{PolynomialCore.Polynomial}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{PolynomialCore.Polynomial}') | Sturm sequence for this polynomial |

<a name='M-PolynomialCore-Polynomial-getSturmSequence'></a>
### getSturmSequence() `method`

##### Summary

Gets Sturm sequence for this polynomial

##### Returns

Sturm sequence

##### Parameters

This method has no parameters.

<a name='M-PolynomialCore-Polynomial-newtonRaphson-System-Double,PolynomialCore-Polynomial-'></a>
### newtonRaphson(x0,derivative) `method`

##### Summary

Finds approximate root

##### Returns

Approximate root

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x0 | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | Approximate root |
| derivative | [PolynomialCore.Polynomial](#T-PolynomialCore-Polynomial 'PolynomialCore.Polynomial') | Derivative of this polynomial |

<a name='M-PolynomialCore-Polynomial-parseCoefficient-System-String-'></a>
### parseCoefficient(coefficient) `method`

##### Summary

Parses string coefficient to double coefficient

##### Returns

Coefficient as double

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| coefficient | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Coefficient as string |

<a name='M-PolynomialCore-Polynomial-y-System-Double-'></a>
### y(x) `method`

##### Summary

Gets value of W(x) for this polynomial

##### Returns

Value of y

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | x |
