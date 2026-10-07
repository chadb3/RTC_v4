using RTC_v4;
Console.WriteLine("Hello, World!");
Chapter_1_Putting_it_Together();
Chapter_2_Putting_it_Together();

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

static void Chapter_2_Putting_it_Together()
{
    Console.WriteLine("Chapter 2 - Graph");
    RTTuple start = RTTuple.point(0, 1, 0);
    RTTuple velocity = RTTuple.vector(1, 1.8, 0).normalize() * 11.25;
    Projectile p = new Projectile(start, velocity);
    RTTuple gravity = RTTuple.vector(0, -0.1, 0);
    RTTuple wind = RTTuple.vector(-0.01, 0, 0);
    Environment e = new Environment(gravity, wind);
    Canvas c = new Canvas(900, 500);
    while(p.position.y>0)
    {
        p = tick(e, p);
        int x = (int)Math.Round(p.position.x, MidpointRounding.AwayFromZero);
        int y = (int)Math.Round(p.position.y, MidpointRounding.AwayFromZero);
        //Console.WriteLine($"x {p.position.x}\ny: {p.position.y}\n");
        if(x >=0 && y>=0 && x<c.width&&y<c.height)
        {
            //Console.WriteLine("hit");
            // AI found my logic was mostly correct, but the "-1" was added to account for zero index
            c.WritePixle(RTTuple.color(1, 0, 0), x, c.height-y-1);
        }
        else
        {
            //Console.WriteLine("MISS!");
        }
    }
    c.CanvasToPPM("Try1");
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