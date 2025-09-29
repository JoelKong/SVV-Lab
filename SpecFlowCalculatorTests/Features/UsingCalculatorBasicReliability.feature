Feature: UsingCalculatorBasicReliability
In order to calculate the Basic Musa model's failures/intensities
As a Software Quality Metric enthusiast
I want to use my calculator to do this

@BasicReliability
Scenario: Calculate current failure intensity
	Given I have a calculator
	When I have entered 100 and 10 and 50 into the calculator and press current failure intensity
	Then the reliability result should be "45"

@BasicReliability
Scenario: Calculate current failure intensity with zero failures
	Given I have a calculator
	When I have entered 200 and 0 and 30 into the calculator and press current failure intensity
	Then the reliability result should be "30"

@BasicReliability
Scenario: Calculate current failure intensity with all failures
	Given I have a calculator
	When I have entered 50 and 50 and 25 into the calculator and press current failure intensity
	Then the reliability result should be "0"

# @BasicReliability
# Scenario: Calculate average number of expected failures
#	Given I have a calculator
#	When I have entered 200 and 10 and 50 into the calculator and press average expected failures
#	Then the reliability result should be "86.466"

@BasicReliability
Scenario: Calculate average expected failures with zero time
	Given I have a calculator
	When I have entered 100 and 5 and 0 into the calculator and press average expected failures
	Then the reliability result should be "0"

@BasicReliability
Scenario: Calculate current failure intensity with negative parameters
	Given I have a calculator
	When I have entered -100 and 10 and 50 into the calculator and press current failure intensity
	Then the calculator should display a reliability error message "All parameters must be non-negative"

@BasicReliability
Scenario: Calculate average expected failures with negative time
	Given I have a calculator
	When I have entered 200 and 10 and -50 into the calculator and press average expected failures
	Then the calculator should display a reliability error message "All parameters must be non-negative"