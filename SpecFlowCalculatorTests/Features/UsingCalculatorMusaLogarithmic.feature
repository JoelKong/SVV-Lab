Feature: UsingCalculatorMusaLogarithmic
In order to predict system reliability using advanced modeling
As a system quality engineer
I want to use the Musa Logarithmic model for failure calculations

@MusaLogarithmic
Scenario: Calculate failure intensity using Musa Logarithmic model
	Given I have a calculator
	When I have entered 0.02 and 50 and 100 into the calculator and press Musa failure intensity
	Then the logarithmic result should be "0.01"

@MusaLogarithmic
Scenario: Calculate expected failures using Musa Logarithmic model
	Given I have a calculator
	When I have entered 0.02 and 50 and 30 into the calculator and press Musa expected failures
	Then the logarithmic result should be "23.167"

@MusaLogarithmic
Scenario: Calculate failure intensity with zero execution time
	Given I have a calculator
	When I have entered 0.02 and 50 and 0 into the calculator and press Musa failure intensity
	Then the logarithmic result should be "0.02"

@MusaLogarithmic
Scenario: Calculate Musa failure intensity with invalid parameters
	Given I have a calculator
	When I have entered -0.02 and 50 and 100 into the calculator and press Musa failure intensity
	Then the calculator should display a logarithmic error message "All parameters must be positive"

@MusaLogarithmic
Scenario: Calculate Musa expected failures with zero decay parameter
	Given I have a calculator
	When I have entered 0.02 and 0 and 30 into the calculator and press Musa expected failures
	Then the calculator should display a logarithmic error message "Decay parameter must be greater than zero"