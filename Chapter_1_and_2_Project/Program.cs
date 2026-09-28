using RTC_v4;
Console.WriteLine("Hello, World!");
Chapter_1_Putting_it_Together();

// Chapter 1 Putting It Together end of Chapter "Project"
// This will also be used again at the end of Chapter 2
static void Chapter_1_Putting_it_Together()
{
    //Projectile ret = new Projectile(RTTuple.point(0, 0, 0), RTTuple.vector(1, 1, 1));
    Projectile p = new Projectile(RTTuple.point(0, 1, 0), RTTuple.vector(1, 1, 0).normalize());
    Environment e = new Environment(RTTuple.vector(0, -0.1, 0), RTTuple.vector(-0.01, 0, 0));
    Console.WriteLine($"Pre update: {p}");
    p = tick(e, p);
    Console.WriteLine($"Post update: {p}");
    Console.WriteLine("Starting loop");
    int count = 0;
    while(p.position.y>0)
    {
        p = tick(e, p);
        Console.WriteLine($"{count}: {p}");
        count += 1;
    }
    Console.WriteLine($"After Loop: {p}");
}

static Projectile tick(Environment env, Projectile proj)
{
    RTTuple newPos = proj.position + proj.velocity;
    RTTuple velocity = proj.velocity + env.gravity + env.wind;
    return new Projectile(newPos,velocity);
}


public readonly struct Projectile
{
    public RTTuple position { get; }
    public RTTuple velocity { get; }

    public Projectile(RTTuple position, RTTuple velocity)
    {
        this.position = position;
        this.velocity = velocity;
    }

    public override string ToString()
    {
        return "position: " + position.ToString() + " |~~~~| velocity: " + velocity.ToString();
    }
}

public readonly struct Environment
{
    public RTTuple gravity { get; }
    public RTTuple wind { get; }

    public Environment(RTTuple gravity, RTTuple wind)
    {
        this.gravity = gravity;
        this.wind = wind;
    }

    public override string ToString()
    {
        return gravity.ToString() + " ~~~~ " + wind.ToString();
    }

}