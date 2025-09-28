Feature: UsingCalculatorAvailability
	In order to calculate MTBF and Availability
	As someone who struggles with math
	I want to be able to use my calculator to do this

@Availability
Scenario: Calculating MTBF
	Given I have a calculator
	When I have entered 8760 and 4 into the calculator and press MTBF
	Then the availability result should be "2190"

@Availability  
Scenario: Calculating Availability
	Given I have a calculator
	When I have entered 2190 and 2 into the calculator and press Availability
	Then the availability result should be "0.999087"

@Availability
Scenario: Calculating MTBF with zero failures
	Given I have a calculator
	When I have entered 1000 and 0 into the calculator and press MTBF
	Then the calculator should display an error message "Cannot calculate MTBF with zero failures"

@Availability
Scenario: Calculating Availability with zero MTBF
	Given I have a calculator
	When I have entered 0 and 5 into the calculator and press Availability
	Then the calculator should display an error message "Cannot calculate availability with zero MTBF"

@Availability
Scenario: Calculating Availability with negative values
	Given I have a calculator
	When I have entered -100 and 2 into the calculator and press Availability
	Then the calculator should display an error message "MTBF and MTTR must be positive values"