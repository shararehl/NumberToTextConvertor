# NumberToTextConvertor
Setup 
--------------------------------------------------------------------------------------------------------------------------
In Visual studio, Restore nuget packages on the solution, build it and set NTT.Web.Client as the startup project and run.

Projects Descriptions
--------------------------------------------------------------------------------------------------------------------------

NTT.Common
--------------------------------------------------------------------------------------------------------------------------
A component for converting and formatting decimal/int number to text. This project was implemented with TDD approach along with considering SOLID for better reusability and maintenance.

INumberToTextConvertor: an abstraction which takes a string number as input with or without decimal point and converts it to text.

INumberToTextLanguageFormatter: provides formatting and language support for the convertor. EnglishFormatter, PersianFormatter, EnglishWithDollarFormatter, CustomEnglishWithDollarFormatter are implementation for INumberToTextLanguageFormatter and can be used as desired.

NumberToTextConvertor: An Implementation of INumberToTextConvertor which takes an INumberToTextLanguageFormatter implementation for Converting Number to the desired language format.

--------------------------------------------------------------------------------------------------------------------------
NTT.Common.Tests  
--------------------------------------------------------------------------------------------------------------------------
Contains tests for all combination of INumberToTextConvertor and INumberToTextLanguageFormatter implementations. NUnit was used for writing tests.

--------------------------------------------------------------------------------------------------------------------------
NTT.Web.Server
--------------------------------------------------------------------------------------------------------------------------
An OWIN hosted Web Api providing service for formatting number. The Controller needs an implementation of INumberToTextConvertor which is injected using Autofac. 

 --------------------------------------------------------------------------------------------------------------------------
 NTT.Web.Server.Tests
 --------------------------------------------------------------------------------------------------------------------------
Unit Tests for NTT.Web.Server Controller using NUnit.

--------------------------------------------------------------------------------------------------------------------------
NTT.Web.Client
--------------------------------------------------------------------------------------------------------------------------
A simple frontend application implemented using Angularjs to showcase usage of NTT.Web.Server service.




