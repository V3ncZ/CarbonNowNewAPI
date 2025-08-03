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
            var route = app.MapGroup("Transport").WithTags("Transport");

            route.MapGet("/ListAll", ([FromServices] DAL<Transport> dal) =>
            {
                var transports = dal.ListAll(includes: new[] {"TipoTransporte", "Usuario"});
                if (transports is null)
                {
                    return Results.NoContent();
                }

                var transportResponseList = EntityListToResponseList(transports);

                return Results.Ok(transportResponseList);
            });

            route.MapPost("/Create", ([FromBody] TransportRequest transportRequest, [FromServices] DAL<Transport> dal, [FromServices] CarbonCalculatorService calculator, [FromServices] DAL<TransportType> tipoTransporteDal) =>
            {

                var tipoTransporte = tipoTransporteDal.RecuperarPor(t => t.Id == transportRequest.tipoTransporteId);

                decimal emissao = calculator.CalcularEmissaoDeCarbono(tipoTransporte.EmissaoFatorPorKm, transportRequest.distanciaKm);


                var transport = new Transport(
                    transportRequest.idUsuario,
                    transportRequest.tipoTransporteId,
                    transportRequest.distanciaKm,
                    transportRequest.dtUso,
                    emissao);

                dal.Create(transport);

                var completeTransport = dal.RecuperarPor(a => a.Id == transport.Id, includes: new[] { "TipoTransporte", "Usuario" });

                var transportResponse = EntityToResponse(completeTransport);

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

            route.MapPut("/Update/{id}", ([FromBody] TransportRequest transportRequest, [FromServices] DAL<Transport> dal, [FromRoute] int id, [FromServices] CarbonCalculatorService calculator, [FromServices] DAL<TransportType> tipoTransporteDal) =>
            {
                var transportToUpdate = dal.RecuperarPor(a => a.Id == id);
                if (transportToUpdate is null)
                {
                    return Results.NotFound();
                }

                var tipoTransporte = tipoTransporteDal.RecuperarPor(t => t.Id == transportRequest.tipoTransporteId);

                decimal emissao = calculator.CalcularEmissaoDeCarbono(tipoTransporte.EmissaoFatorPorKm, transportRequest.distanciaKm);

                transportToUpdate.IdUsuario = transportRequest.idUsuario;
                transportToUpdate.TipoTransporteId = transportRequest.tipoTransporteId;
                transportToUpdate.DistanciaKm = transportRequest.distanciaKm;
                transportToUpdate.DtUso = transportRequest.dtUso;
                transportToUpdate.EmissaoCalculada = emissao;

                dal.Update(transportToUpdate);

                var completeTransport = dal.RecuperarPor(a => a.Id == id, includes: new[] { "TipoTransporte", "Usuario" });

                var transportResponse = EntityToResponse(completeTransport);

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
                transport.DistanciaKm,
                transport.DtUso,
                transport.EmissaoCalculada,
                new TransportTypeResponse(
                    transport.TipoTransporte.Id,
                    transport.TipoTransporte.Nome,
                    transport.TipoTransporte.EmissaoFatorPorKm,
                    transport.TipoTransporte.ConformeIso));
            }
    }
}
