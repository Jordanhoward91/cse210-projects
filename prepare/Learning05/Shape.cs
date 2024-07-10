public class Shape
{
	private string _color;

	public string Color
	{
		get { return _color; }
		set { _color = value; }
	}

	public Shape(string color)
	{
		_color = color;
	}

	public virtual double GetArea()
	{
		// Base implementation can be overridden by derived classes
		return 0.0;
	}
}
