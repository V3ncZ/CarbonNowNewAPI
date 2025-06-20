﻿using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record TransportRequest(
        User idUsuario,
        string tipoTransporte,
        int distanciaKm,
        DateTime dtUso,
        int emissaoCalculada,
        bool conformeIso)
    {
    }
}
