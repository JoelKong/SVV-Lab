Feature: UsingCalculatorQualityMetrics
In order to assess software system quality
As a system quality engineer
I want to calculate defect density and SSI for software releases

@QualityMetrics
Scenario: Calculate defect density
	Given I have a calculator
	When I have entered 25 and 5000 into the calculator and press defect density
	Then the quality metrics result should be "0.005"

@QualityMetrics
Scenario: Calculate defect density with zero defects
	Given I have a calculator
	When I have entered 0 and 1000 into the calculator and press defect density
	Then the quality metrics result should be "0"

@QualityMetrics
Scenario: Calculate SSI for successive release
	Given I have a calculator
	When I have entered 10000 and 2000 and 500 into the calculator and press SSI calculation
	Then the quality metrics result should be "12000"

@QualityMetrics
Scenario: Calculate defect density with invalid inputs
	Given I have a calculator
	When I have entered 10 and 0 into the calculator and press defect density
	Then the calculator should display a quality metrics error message "Lines of code must be greater than zero"

@QualityMetrics
Scenario: Calculate SSI with negative values
	Given I have a calculator
	When I have entered 5000 and -1000 and 200 into the calculator and press SSI calculation
	Then the calculator should display a quality metrics error message "All SSI values must be non-negative"