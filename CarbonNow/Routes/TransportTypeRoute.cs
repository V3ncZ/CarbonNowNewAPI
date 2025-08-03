using CarbonNow.Model;
using CarbonNow.Request;
using CarbonNow.Response;
using CarbonNow.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonNow.Routes
{
    public static class TransportTypeRoute
    {
        public static void TransportTypeRoutes(this WebApplication app)
        {
            var route = app.MapGroup("TransportType").WithTags("TransportType");


            route.MapGet("/ListAll", ([FromServices] DAL<TransportType> dal) =>
            {
                var transportTypeList = dal.ListAll();
                if (transportTypeList is null) 
                { 
                    return Results.NoContent();
                }

                var transportTypeListResponse = EntityListToResponseList(transportTypeList);

                return Results.Ok(transportTypeListResponse);
            });

            route.MapPost("/Create", ([FromServices] DAL<TransportType> dal, [FromBody] TransportTypeRequest transportTypeRequest) =>
            {
                var transportType = new TransportType(
                    transportTypeRequest.nome,
                    transportTypeRequest.emissaoFatorPorKm);

                dal.Create(transportType);

                var transportTypeResponse = EntityToResponse(transportType);

                return Results.Ok(transportTypeResponse);
            });

            route.MapDelete("/Delete/{id}", ([FromServices] DAL<TransportType> dal, [FromRoute] int id) =>
            {
                var transportType = dal.RecuperarPor(a => a.Id == id);
                if (transportType is null)
                {
                    return Results.NotFound();
                }

                dal.Delete(transportType);

                return Results.NoContent();
            });

            route.MapPut("/Update/{id}", ([FromServices] DAL<TransportType> dal, [FromBody] TransportTypeRequest transportTypeRequest, [FromRoute] int id) =>
            {
                var transportType = dal.RecuperarPor(a => a.Id == id);
                if (transportType is null) 
                {
                    return Results.NotFound();
                }

                transportType = new TransportType(
                    id,
                    transportTypeRequest.nome,
                    transportTypeRequest.emissaoFatorPorKm);

                dal.Update(transportType);

                var transportTypeResponse = EntityToResponse(transportType);

                return Results.Ok(transportTypeResponse);
            });
        }

        private static ICollection<TransportTypeResponse> EntityListToResponseList(IEnumerable<TransportType> transportType)
        {
            return transportType.Select(a => EntityToResponse(a)).ToList();
        }

        private static TransportTypeResponse EntityToResponse(TransportType transportType)
        {
            return new TransportTypeResponse(
                transportType.Id,
                transportType.Nome,
                transportType.EmissaoFatorPorKm,
                transportType.ConformeIso);
        }

    }
}
