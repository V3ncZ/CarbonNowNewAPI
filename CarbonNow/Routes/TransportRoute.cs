using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Response;
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

                var transportResponseList = EntityListToResponseList(transports);

                return Results.Ok(transportResponseList);
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

                var transportResponse = EntityToResponse(transport);

                return Results.Ok(transportResponse);
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
                if (transportToUpdate is null)
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

                var transportResponse = EntityToResponse(transportToUpdate);

                return Results.Ok(transportResponse);

            });
        }
        private static ICollection<TransportResponse> EntityListToResponseList(IEnumerable<Transport> TransportList)
            {
                return TransportList.Select(a => EntityToResponse(a)).ToList();
            }
        private static TransportResponse EntityToResponse(Transport transport)
            {
                return new TransportResponse(
                    transport.Id,
                    transport.IdUsuario,
                    transport.TipoTransporte,
                    transport.DistanciaKm,
                    transport.DtUso,
                    transport.EmissaoCalculada,
                    transport.ConformeIso);
            }
    }
}
