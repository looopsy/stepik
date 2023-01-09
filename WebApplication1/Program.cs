var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/diameter/{dm}/{dl}", diamRequest);
app.MapGet("/know/{a}/{b}/{c}", perimeterRequest);
app.Run();


string diamRequest(int dm, int dl)
{
    double a = Math.Sqrt(Math.Pow(dl, 2) * 2);
    StreamWriter sw = new StreamWriter("./log.txt", true);
    if (a <= dm)
    {
        sw.WriteLine("Диаметр - " + dm + ", Длинна - " + dl + " Выпилить брусок возможно");
        sw.Close();
        return $"Выпилить брусок возможно.";

    }
    sw.WriteLine("Диаметр - " + dm + ", Длинна - " + dl + " Выпилить брусок невозможно");
    sw.Close();
    return $"Выпилить брусок невозможно.";
}

string perimeterRequest(int a, int b, int c)
{
    int p = a+b+c;
    StreamWriter sw = new StreamWriter("./log.txt", true);
    double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    sw.WriteLine("A -" + a + ", B - " + b + ", C - " + c + $" Периметр: {p}, Площадь: {s}");
    sw.Close();
    return $"Периметр: {p}, Площадь: {s}";

}