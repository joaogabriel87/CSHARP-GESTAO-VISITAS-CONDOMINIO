using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Santi.Context;
using Santi.Models;

namespace Santi.Services
{
    public class VisitantesServices
    {
        private readonly VisitanteContext _context;

        public VisitantesServices(VisitanteContext context)
        {
            _context = context;
        }

        public async Task<Visitante> NovoVisitante(Visitante visitante)
        {
            bool VisitanteExistente = await _context.VisitanteDb.AnyAsync(u => u.CPF == visitante.CPF);
            if (VisitanteExistente)
            {
                throw new Exception("Esse visitante já esta cadastrado");
            }

            if (visitante.CPF.Length != 11 || !visitante.CPF.All(char.IsNumber))
            {
                throw new Exception("CPF invalido");
            }
            if (visitante.Telefone.Length != 11 || !visitante.Telefone.All(char.IsNumber))
            {
                throw new Exception("Telefone invalido");
            }

            await _context.AddAsync(visitante);
            await _context.SaveChangesAsync();

            return visitante;
        }
    }
}