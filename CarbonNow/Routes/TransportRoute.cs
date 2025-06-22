using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonNow.Routes
{
    public static class TransportRoute
    {
        public static void TransportRoutes(this WebApplication app)
        {
            var route = app.MapGroup("Transport");

            route.MapGet("/ListAll", ([FromServices] DAL<Transport> dal) =>
            {
                var transports = dal.ListAll();
                if (transports is null)
                {
                    return Results.NoContent();
                }

                return Results.Ok(transports);
             });

            route.MapPost("/Create", ([FromBody] TransportRequest transportRequest, [FromServices] DAL<Transport> dal) =>
            {
                var transport = new Transport(
                    transportRequest.idUsuario,
                    transportRequest.tipoTransporte,
                    transportRequest.distanciaKm,
                    transportRequest.dtUso,
                    transportRequest.emissaoCalculada,
                    transportRequest.conformeIso);

                dal.Create(transport);

                return Results.Ok(transport);
            });

            route.MapDelete("/Delete/{id}", ([FromServices] DAL<Transport> dal, [FromRoute] int id) =>
            {
                var transport = dal.RecuperarPor(a => a.Id == id);
                if (transport is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(transport);

                return Results.NoContent();
            });

            route.MapPut("/Update/{id}", ([FromBody] TransportRequest transportRequest, [FromServices] DAL<Transport> dal, [FromRoute] int id) =>
            {
                var transportToUpdate = dal.RecuperarPor(a => a.Id == id);
                if(transportToUpdate is null)
                {
                    return Results.NotFound();
                }

                transportToUpdate = new Transport(
                    transportRequest.idUsuario,
                    transportRequest.tipoTransporte,
                    transportRequest.distanciaKm,
                    transportRequest.dtUso,
                    transportRequest.emissaoCalculada,
                    transportRequest.conformeIso
                    );

                dal.Update(transportToUpdate);

                return Results.Ok(transportToUpdate);

            });
        }
    }
}
