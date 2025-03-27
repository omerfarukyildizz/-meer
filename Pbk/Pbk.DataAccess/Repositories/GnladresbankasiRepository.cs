using Pbk.Core.Utilities.Uniq;
using Pbk.DataAccess.Context;
using Pbk.Entities.Models;
using Pbk.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.DataAccess.Repositories
{
    
    //internal sealed class GnladresbankasiRepository : RepositoryBarsis<Gnladresbankasi>, IGnladresbankasiRepository
    //{
    //    private readonly ContextBarsan _context;
    //    public GnladresbankasiRepository(ContextBarsan context) : base(context)
    //    {
    //        _context = context;
    //    }

    //    public IEnumerable<object> OceanNotifiy(string? sarch)
    //    {
    //        var gnladresbankasi = !string.IsNullOrWhiteSpace(sarch) ?
    //            _context.Gnladresbankasi.Where(w => w.gonderici_alici == true &&
    //            (Regex_Helper.IsNumber(sarch) ? w.kodu == Regex_Helper.ConvertInt(sarch) : w.adi.Contains(sarch)))
    //            : _context.Gnladresbankasi.Where(w => w.gonderici_alici == true);

    //        var query = from GAB in gnladresbankasi
    //                    select new
    //                    {
    //                        GAB.kodu,
    //                        GAB.adi,
    //                        GAB.il,
    //                        GAB.telefon,
    //                        GAB.ilgili,
    //                        adres = GAB.adres1 + " " + GAB.adres2,
    //                    };

    //        return query.Take(500).ToList();
    //    }
    //}
}
