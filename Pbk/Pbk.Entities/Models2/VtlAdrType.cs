using System;
using System.Collections.Generic;

namespace Pbk.Entities.Models2;

public partial class VtlAdrType
{
    public int AdrTypeId { get; set; }

    public string? Type { get; set; }

    public string? UN_Nummer { get; set; }

    public string? UN_Unternummer { get; set; }

    public string? Hauptgefahr { get; set; }

    public string? Nebengefahr1 { get; set; }

    public string? Nebengefahr2 { get; set; }

    public string? Nebengefahr3 { get; set; }

    public string? Nebengefahr4 { get; set; }

    public string? Klassifizierungscode { get; set; }

    public string? Verpackungsgruppe { get; set; }

    public string? Multiplikator { get; set; }

    public string? N_A_G_Kennzeichen { get; set; }

    public string? Benennung_DE { get; set; }

    public string? Benennung_GB { get; set; }

    public string? Benennung_FR { get; set; }

    public string? Beförderungskategorie { get; set; }

    public string? Klasse { get; set; }

    public string? LQ { get; set; }

    public string? Kennzeichen_der_gefGüter_mit_hohem_Gefahrenpotential { get; set; }

    public string? Änderungsdatum { get; set; }

    public string? ADRVersion { get; set; }

    public string? ADRGueltigBis { get; set; }

    public string? Tunnelvorschrift { get; set; }

    public string? Sondervorschriften { get; set; }

    public string? Stammdaten_FLUESSIG { get; set; }

    public string? VTLSTRG { get; set; }
}
