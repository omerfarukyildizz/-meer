using System;
using System.Collections.Generic;

namespace Pbk.Entities.Views;

public partial class Dnz_NakGelirGider_v1
{
    public string? departman { get; set; }

    public string? yerkod { get; set; }

    public string yer { get; set; } = null!;

    public int? Seferno { get; set; }

    public int? Yukno { get; set; }

    public string? Firmano { get; set; }

    public string? Adi { get; set; }

    public string? Gelirgiderkodu { get; set; }

    public string? GelirAdi { get; set; }

    public double? Gelirtutar { get; set; }

    public double? Gidertutar { get; set; }

    public double? EstGelirtutar { get; set; }

    public double? Estgidertutar { get; set; }

    public string Doviztur { get; set; } = null!;

    public double KZ { get; set; }

    public DateTime? Tarih { get; set; }

    public string? faturano { get; set; }

    public string? Durum { get; set; }

    public int? yyil { get; set; }
}
