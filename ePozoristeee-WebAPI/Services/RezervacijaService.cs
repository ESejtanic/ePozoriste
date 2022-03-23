using AutoMapper;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using ePozoriste.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePozoriste.WebAPI.Services
{
    public class RezervacijaService : IRezervacijaService
    {

        private readonly ePozoristeContext _context;
        private readonly IMapper _mapper;
        public RezervacijaService(ePozoristeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<Model.Rezervacija> Get(RezervacijaSearchRequest search)
        {

            var q = _context.Set<Database.Rezervacije>().AsQueryable();
            if (!string.IsNullOrEmpty(search?.Ime) && search?.KupacId.HasValue == true)
            {
                q = q.Where(s => s.Kupac.Ime.Equals(search.Ime) && s.KupacId == search.KupacId);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Ime))
                {
                    q = q.Where(x => x.Kupac.Ime.ToLower().StartsWith(search.Ime) || x.Kupac.Ime.ToUpper().StartsWith(search.Ime));
                }
                if (search?.KupacId.HasValue == true)
                {
                    q = q.Where(s => s.Kupac.KupacId == search.KupacId);
                }
            }


            if (search?.PrikazivanjeId.HasValue == true)
            {
                q = q.Where(s => s.Prikazivanje.PrikazivanjeId == search.PrikazivanjeId);
            }

            var list = q.ToList();
            var result = _mapper.Map<List<Model.Rezervacija>>(list);
            foreach (var item in result)
            {
                item.UkupnaCijena = _context.Rezervacije.Where(x => x.RezervacijaId == item.RezervacijaId).Select(x => x.Prikazivanje.Cijena).FirstOrDefault();
            }
            return result;
        }


        public Model.Rezervacija GetById(int id)
        {
            var entity = _context.Rezervacije.Find(id);

            return _mapper.Map<Model.Rezervacija>(entity);
        }

        public Model.Rezervacija Insert(RezervacijaUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Rezervacije>(request);
            _context.Rezervacije.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);
        }

        public Model.Rezervacija Update(int id, RezervacijaUpsertRequest request)
        {
            var entity = _context.Rezervacije.Find(id);
            _context.Rezervacije.Attach(entity);
            _context.Rezervacije.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);
        }

        public Model.Rezervacija Delete(int id)
        {
            var entity = _context.Rezervacije.Find(id);

            _context.Rezervacije.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);


        }
    }
}
