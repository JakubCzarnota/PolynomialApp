# PolynomialApp

### Aplication that allows user to get properties of polynomial, visual interpretation of it and to do mathemtical operations on two polynomials

____
## How does it work?

### Input polynomial

![Gif showing ho to input polynomial gif](./input.gif)

### See properties and graph of your polynomial

![gif showing how application show polynomial's properties and math graph](./see-properties-and-graph.gif)

### Do arithmetic operations (add, subtract, multiply and devide by second polynomia)

![Gif showing how you can do arithmetic operations with second polynomial](./do-arithmetic-operations.gif)

____
## Technical documentation

### Instalation process

#### Requirements
- Windows 10 or newer
- .NET SDK
- Visual Studio (optional) 

#### Using Visual Studio
1. Clone the repository
2. Open ``PolynomialApp.sln`` using Visual Studio 

#### Using .NET CLI
1. Clone the repository
2. Open CMD in repository folder
3. Use ``dotnet restore`` to restore dependencies
4. Use ``dotnet run`` to run application or ``dotnet build`` to build it

### Components

#### The aplication consists of two components  

- [PolynomialUI](PolynomialUI.md) - responsible for displaying the UI

- [PolynomialCore](PolynomialCore.md) - responsible for the core logic of the application