using System;

public class Fraction
{
	private int numerator;
	private int denominator;

	// Constructor with no parameters (initializes to 1/1)
	public Fraction()
	{
		numerator = 1;
		denominator = 1;
	}

	// Constructor with one parameter (initializes to numerator/1)
	public Fraction(int numerator)
	{
		this.numerator = numerator;
		this.denominator = 1;
	}

	// Constructor with two parameters
	public Fraction(int numerator, int denominator)
	{
		this.numerator = numerator;
		this.denominator = denominator;
	}

	// Getter for numerator
	public int GetNumerator()
	{
		return numerator;
	}

	// Setter for numerator
	public void SetNumerator(int numerator)
	{
		this.numerator = numerator;
	}

	// Getter for denominator
	public int GetDenominator()
	{
		return denominator;
	}

	// Setter for denominator
	public void SetDenominator(int denominator)
	{
		this.denominator = denominator;
	}

	// Method to return the fraction as a string
	public string GetFractionString()
	{
		return $"{numerator}/{denominator}";
	}

	// Method to return the decimal value of the fraction
	public double GetDecimalValue()
	{
		return (double)numerator / denominator;
	}
}
