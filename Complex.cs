class Complex
{
    private double real;
    private double imaginary;

    public double Real { get; set; }
    public double Imaginary { get; set; }

    public double Module
    {
        get
        {
            return Math.Sqrt(imaginary * imaginary + real * real);
        }
        private set { }
    }

    public double Argument
    {
        get { return Math.Asin(imaginary / Module); }
        private set { }
    }

    private Complex(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    public static Complex Alg(double real, double imaginary)
    {
        return new Complex(real, imaginary);
    }

    public static Complex Geom(double module, double argument)
    {
        return new Complex(module * Math.Cos(module), module * Math.Sin(argument));
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.real + b.real, a.imaginary + b.imaginary);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.real - b.real, a.imaginary - b.imaginary);
    }

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(a.real * b.real - a.imaginary * b.imaginary, a.real * b.imaginary + b.real * a.imaginary);
    }

    public static Complex operator /(Complex a, Complex b)
    {
        var c = a * new Complex(b.real, -b.imaginary);
        var z = b.real * b.real - b.imaginary * b.imaginary;

        if (z == 0) throw new ArgumentException("В знаменателе ноль");
        return new Complex(c.real / z, c.imaginary / z);
    }

    public override string ToString()
    {
        if (imaginary > 0) return $"{real} + {imaginary}i";
        return $"{real} - {imaginary}i";
    }
}

