namespace CarbonNow.Routes
{
    public static class TransportRoute
    {
        public static void TransportRoutes(this WebApplication app)
        {
            var route = app.MapGroup("Transport");

            route.MapGet("/ListAll", ([FromBody]))
        }
    }
}
